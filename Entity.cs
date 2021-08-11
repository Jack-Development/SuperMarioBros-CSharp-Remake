using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace SuperMarioBros
{
    class Entity
    {
        // Entity Variables
        private string name;
        public string ID;
        private int posX;
        private int posY;
        protected int sizeX;
        protected int sizeY;
        private float fltXVel;
        private double fltYVel;
        private bool active = true;
        private int scaleSize;
        private bool isGrounded;
        private double fallHeight = 0;
        private bool isPowerUp;
        private int powerUpState;
        private bool isEnemy;
        private bool isCoin;
        private bool isStatic;
        private bool isBounce;
        private bool fromBlock;
        private int scoreWorth;
        private bool isAnimated;
        private int animFrames;
        private bool doesJump;
        private bool doesCollide;
        List<string[]> entityLookUp;
        Rectangle recPosition;
        Rectangle fallDetect;
        List<Bitmap> leftSprite = new List<Bitmap>();
        List<Bitmap> rightSprite = new List<Bitmap>();
        List<Bitmap> squishSprite = new List<Bitmap>();
        List<TextureBrush> righttBrush = new List<TextureBrush>();
        List<TextureBrush> lefttBrush = new List<TextureBrush>();
        List<TextureBrush> squishtBrush = new List<TextureBrush>();
        List<List<TextureBrush>> listHandler = new List<List<TextureBrush>>();
        List<TextureBrush> activetBrush;

        // Direction: 2 = None, 1 = Right, 0 = Left
        int direction;

        float offset = 0;
        float startingOffset;
        float previousOffset;

        bool intersect;

        bool addScore = false;
        bool addCoin = false;

        int jumpMultipy = 0;

        int activeCounter = 0;

        bool oneLoop;
        int currentFrame = 0;
        int animBuffer;
        int animBufferCount = 0;

        bool deathActive = false;

        float offsetAddition = 0;
        float distance = 0;
        int oldRec = 0;

        bool squishable = false;
        bool squashed = false;
        int squishCounter = 0;
        bool koopaSquash = false;

        bool DebugMode = false;

        public Entity(string IDPass, int startPosX, int startPosY, int startSizeX, int startSizeY, bool isStartGrounded, int scaleSize, float offset, List<string[]> entityLookUpPass, int DirectionPass, int multiplyJump, bool Debug)
        {
            DebugMode = Debug;
            entityLookUp = entityLookUpPass;
            for (int i = 0; i < entityLookUp.Count; i++)
            {
                // Finds entity based on ID provided
                if(entityLookUp[i][1] == IDPass)
                {
                    ID = i.ToString();
                }
            }

            // Assigns variables based on CSV entityList
            name = entityLookUp[Convert.ToInt32(ID)][1];
            isPowerUp = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][2]) != 0;
            isEnemy = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][3]) != 0;
            isCoin = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][4]) != 0;
            powerUpState = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][5]);
            isStatic = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][6]) != 0;
            isBounce = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][7]) != 0;
            fromBlock = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][8]) != 0;
            scoreWorth = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][9]);
            isAnimated = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][10]) != 0;
            animFrames = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][11]);
            doesJump = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][12]) != 0;
            doesCollide = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][13]) != 0;
            oneLoop = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][14]) != 0;
            animBuffer = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][15]);
            jumpMultipy = multiplyJump;
            direction = DirectionPass;
            posX = startPosX;

            // Offsets start position based on whether the entity is in a block
            if (fromBlock)
            {
                posY = startPosY - scaleSize;
            }
            else
            {
                posY = startPosY;
            }
            sizeX = startSizeX;

            // Sets inital Y height based on if there is a resource with the same name
            if (((Bitmap)Properties.Resources.ResourceManager.GetObject(entityLookUp[Convert.ToInt32(ID)][1] + "1")) != null)
            {
                if (((Bitmap)Properties.Resources.ResourceManager.GetObject(entityLookUp[Convert.ToInt32(ID)][1] + "1")).Size.Height == 64)
                {
                    sizeY = startSizeY * 2;
                    posY -= scaleSize;
                }
                else
                {
                    sizeY = startSizeY;
                }
            }
            else
            {
                sizeY = startSizeY;
            }
            this.scaleSize = scaleSize;

            // Sets up the entity if it's going to move
            if (!isStatic)
            {
                recPosition = new Rectangle((int)(posX - offset), posY, sizeX, sizeY);
                fallDetect = new Rectangle((int)(posX - offset), posY + 1, sizeX, sizeY);
                if (isEnemy)
                {
                    fltXVel = ((7.35f * scaleSize) * (20f / 1000f)) / 3;
                    squishable = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][16]) != 0;
                    koopaSquash = Convert.ToInt32(entityLookUp[Convert.ToInt32(ID)][17]) != 0;
                }
                else
                {
                    fltXVel = (7.35f * scaleSize) * (20f / 1000f);
                }
            }
            else
            {
                recPosition = new Rectangle(posX, posY, sizeX, sizeY);
            }
            startingOffset = offset;

            // Runs inital setup
            Setup();
            activetBrush = righttBrush;

            // Allows for the entity to complete an inital jump if required
            if (doesJump)
            {
                Jump();
            }

            // Flips X Vel if starts by moving the opposite direction
            if(direction == 0)
            {
                fltXVel = -fltXVel;
            }
            else if(direction == 2) // Direction 2 represents no direction
            {
                fltXVel = 0;
            }
        }

        void Setup()
        {
            // Implements all unique frames for the entity based on what is required from the CSV file
            listHandler.Add(lefttBrush);
            listHandler.Add(righttBrush);

            if (squishable)
            {
                listHandler.Add(squishtBrush);
            }

            if (isAnimated)
            {
                for(int i = 1; i < animFrames + 1; i++)
                {
                    ListAdd(rightSprite, righttBrush, (i - 1), new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject(name + i.ToString())), false);
                    ListAdd(leftSprite, lefttBrush, (i - 1), new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject(name + i.ToString())), true);
                }
            }
            else
            {
                ListAdd(rightSprite, righttBrush, 0, new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject(name)), false);
                ListAdd(leftSprite, lefttBrush, 0, new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject(name)), true);
            }

            if (squishable)
            {
                ListAdd(squishSprite, squishtBrush, 0, new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Squish")), false);
            }

        }

        // The operation used to setup and implement images into a texture brush and makes the entity transparent
        public void ListAdd(List<Bitmap> bitmapInput, List<TextureBrush> textureInput, int placement, Bitmap inputBitmap, bool flipped)
        {
            bitmapInput.Add((new Bitmap(inputBitmap)));
            if (flipped)
                bitmapInput[placement].RotateFlip(RotateFlipType.RotateNoneFlipX);
            bitmapInput[placement].MakeTransparent(Color.White);
            textureInput.Add(new TextureBrush(bitmapInput[placement]));
            textureInput[placement].WrapMode = System.Drawing.Drawing2D.WrapMode.Clamp;
            if (!isStatic)
            {
                textureInput[placement].TranslateTransform(posX - startingOffset, posY);
            }
            else
            {
                textureInput[placement].TranslateTransform(posX, posY);
            }
        }

        // Main position handling system
        public void ChangePosition(int x, int y)
        {
            if (!squashed)
            {
                if (ID == "7")
                {
                    x = recPosition.X;
                }
                else if (ID == "11")
                {
                    x = recPosition.X - ((recPosition.X - x) * 3);
                }
                if (!isStatic)
                {
                    foreach (List<TextureBrush> list in listHandler)
                    {
                        foreach (TextureBrush brush in list)
                        {
                            brush.TranslateTransform(-(recPosition.X - x), -(recPosition.Y - y));
                        }
                    }
                    recPosition.Location = new Point(x, y);
                    fallDetect.Location = new Point(x, y + 1);
                }
            }
        }

        // Used when only moving the x-axis, similar to previous function
        public void ChangePosition(int x)
        {
            if (!squashed)
            {
                if (ID == "7")
                {
                    x = recPosition.X;
                }
                else if (ID == "11")
                {
                    x = recPosition.X - ((recPosition.X - x) * 3);
                }
                if (!isStatic)
                {
                    foreach (List<TextureBrush> list in listHandler)
                    {
                        foreach (TextureBrush brush in list)
                        {
                            brush.TranslateTransform(-(recPosition.X - x), 0);
                        }
                    }
                    recPosition.Location = new Point(x, (int)(recPosition.Y));
                    fallDetect.Location = new Point(x, (int)(fallDetect.Y + 1));
                }
            }
        }

        // Ignores limiations implemented by the previous functions
        public void ChangePositionOverride(int x, int y)
        {
                foreach (List<TextureBrush> list in listHandler)
                {
                    foreach (TextureBrush brush in list)
                    {
                        brush.TranslateTransform(-(recPosition.X - x), -(recPosition.Y - y));
                    }
                }
                recPosition.Location = new Point(x, y);
                fallDetect.Location = new Point(x, y + 1);
        }

        public void Update(PaintEventArgs e, float newOffset)
        {
            activeCounter++;

            // Updates offset
            offset = newOffset - startingOffset;

            // Deletes entity if marked to die
            if (deathActive)
            {
                if (activeCounter > squishCounter)
                {
                    Delete();
                }
                newOffset += offsetAddition;
            }
            else
            {
                distance += recPosition.X - oldRec;
            }
            oldRec = recPosition.X;

            // Allows the entity to move with the offset of the screen
            if (isStatic)
            {
                recPosition = new Rectangle(posX - Convert.ToInt32(newOffset), recPosition.Y, sizeX, sizeY);
            }
            else
            {
                 recPosition = new Rectangle(Convert.ToInt32(recPosition.X + (previousOffset - offset)), recPosition.Y, sizeX, sizeY);
            }
            foreach (List<TextureBrush> list in listHandler)
            {
                foreach (TextureBrush tBrush in list)
                {
                    tBrush.TranslateTransform(recPosition.X - oldRec, 0, System.Drawing.Drawing2D.MatrixOrder.Append);
                }
            }

            // Draws red cube in collision area if debug mode is enabled
            if (DebugMode)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), recPosition);
            }

            e.Graphics.FillRectangle(activetBrush[currentFrame], recPosition);

            previousOffset = offset;
        }

        public void Delete()
        {
            active = false;
        }

        public void Squish(ref List<Entity> entityListRef, List<string[]> entityLookUpPass, float entityOffset, Player Mario, float speed, ref int invTimer, int timer)
        {
            // Sets enemy variables if they are squished
            if (squishable)
            {
                squishCounter = activeCounter + 300;
                deathActive = true;
                isEnemy = false;
                activetBrush = squishtBrush;
                currentFrame = 0;
                isAnimated = false;
                squashed = true;
            }
            else if (koopaSquash) // If it's a Koopa then it spawns a shell
            {
                Debug.WriteLine(name);
                entityListRef.Add(new Entity(name + "Shell", (int)(recPosition.X + entityOffset), (int)(recPosition.Y + scaleSize), 1 * scaleSize, 1 * scaleSize, true, scaleSize, entityOffset, entityLookUpPass, 2, 0, DebugMode));
                Delete();
            }
            else
            {
                // If the entity is a shell then it is propelled in the opposite direction it was hit
                if (Convert.ToInt32(ID) == 18)
                {
                    invTimer = timer + 5;
                    if (Mario.GetRecPosition().X + (scaleSize / 2) > recPosition.X + (scaleSize / 2))
                    {
                        SetFltXVel(-(speed * 1.5f));
                    }
                    else
                    {
                        SetFltXVel((speed * 1.5f));
                    }
                }
                else
                {
                    Delete();
                }
            }
        }

        public void Jump()
        {
            // Makes the entity jump
            setGrounded(false);
            if (jumpMultipy == 1)
            {
                fallHeight = 19.62f;
            }
            else if(jumpMultipy == -1)
            {
                fallHeight = 6f;
            }
            else
            {
                fallHeight = 9.81f;
            }
        }

        public void setCurrentFrame(int setFrame)
        {
            // Handles animation
            if (setFrame < 0)
            {
                Delete();
            }
            else
            {
                animBufferCount++;
                if (animBufferCount == animBuffer)
                {
                    animBufferCount = 0;
                    currentFrame = setFrame;
                }
            }
        }

        public void flipDirection()
        {
            // Toggles the direction of the entity
            fltXVel = -fltXVel;
            if(direction == 1)
            {
                direction = 0;
            }
            else
            {
                direction = 1;
            }
        }

        public void setGrounded(bool newState)
        {
            // If it is the coin out an empty question block
            if (newState == true && ID == "7")
            {
                if (activeCounter > 100)
                {
                    Delete();
                    addScore = true;
                    addCoin = true;
                }
            }
            // If it is grounded and need to jump
            if (newState == true && doesJump)
            {
                Jump();
            }
            else
            {
                isGrounded = newState;
            }
        }

        // Get / Set functions:

        public bool isActive()
        {
            return active;
        }

        public Rectangle GetRecPosition()
        {
            return recPosition;
        }

        public Rectangle GetFallDetectRec()
        {
            return fallDetect;
        }

        public void SetIntersect(bool newIntersect)
        {
            intersect = newIntersect;
        }

        public bool GetIntersect()
        {
            return intersect;
        }

        public bool getGrounded()
        {
            return isGrounded;
        }

        public void setFallHeight(double newHeight)
        {
            fallHeight = newHeight;
        }

        public double getFallHeight()
        {
            return fallHeight;
        }

        public void SetFltYVel(double yVel)
        {
            fltYVel = yVel;
        }

        public double GetFltYVel()
        {
            return fltYVel;
        }

        public int GetSizeY()
        {
            return sizeY;
        }

        public void SetSizeY(int newSizeY)
        {
            sizeY = newSizeY;
        }

        public int GetSizeX()
        {
            return sizeX;
        }

        public void SetSizeX(int newSizeX)
        {
            sizeX = newSizeX;
        }

        public void SetFltXVel(float xVel)
        {
            fltXVel = xVel;
        }

        public float GetFltXVel()
        {
            return fltXVel;
        }

        public bool CheckPowerUp()
        {
            return isPowerUp;
        }

        public int GetPowerUpState()
        {
            return powerUpState;
        }

        public bool CheckEnemy()
        {
            return isEnemy;
        }

        public bool getStatic()
        {
            return isStatic;
        }

        public int getScore()
        {
            return scoreWorth;
        }
        
        public bool getAnimated()
        {
            return isAnimated;
        }

        public int getCurrentFrame()
        {
            return currentFrame;
        }

        public int getTotalFrames()
        {
            return animFrames;
        }

        public bool getAddScore()
        {
            return addScore;
        }

        public void setAddScore(bool newScoreState)
        {
            addScore = newScoreState;
        }

        public bool checkJump()
        {
            return doesJump;
        }

        public bool getCoin()
        {
            return addCoin;
        }

        public void setCoin(bool newCoin)
        {
            addCoin = newCoin;
        }

        public bool CheckCoin()
        {
            return isCoin;
        }

        public void setActive(bool newActive)
        {
            active = newActive;
        }

        public int getID()
        {
            return Convert.ToInt32(ID);
        }

        public bool getCollide()
        {
            return doesCollide;
        }

        public string getName()
        {
            return name;
        }

        public bool isOneLoop()
        {
            return oneLoop;
        }
    }
}
