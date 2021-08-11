using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace SuperMarioBros
{
    class Player
    {
        protected int posX;
        protected int posY;
        protected int sizeX;
        protected int sizeY;
        private float fltSpeed;
        private float fltXVel;
        private double fltYVel;
        private bool controllable;
        protected bool isGrounded;
        protected bool isCrouching;
        protected bool poleState;
        protected Rectangle recPosition;
        protected Rectangle hitBox;
        protected Rectangle fallDetect;
        protected Brush drawingBrushColour;
        protected TextureBrush activetBrush;
        protected string direction;
        protected bool flipped;
        protected string prefix;
        protected int currentFrame = 0;
        protected int totalFrames;
        protected bool boomerangEffect = false;
        protected bool moving = false;
        protected int frameCounter = 0;
        protected int state = 0;
        protected bool addLife = false;
        protected bool specialActive = false;
        protected int specialLength = 30;
        protected int specialCounter;
        protected int specialFrame = 0;
        protected int scaleSize;
        protected int starState = 0;
        protected int starSubCounter = 0;
        protected int starLength = 0;
        protected int memoryState = 0;
        protected bool running = false;
        protected int targetRate = 20;
        protected int playerID = 0;
        protected string playerName;

        protected bool DebugMode = false;

        // 0 - Small Mario
        // 1 - Big Mario
        // 2 - Fire Mario
        // 3 - Small Star Mario
        // 4 - Big Star Mario
        // 5 - Add one life

        // 0 - Mario
        // 1 - Luigi

        public Player(int startPosX, int startPosY, int startSizeX, int startSizeY, bool isStartGrounded, Brush drawingBrushColour, int inputScaleSize, bool controllableInput, int startState, bool debug, int inputPlayerID)
        {
            playerID = inputPlayerID;
            if(playerID == 0)
            {
                playerName = "Mario";
            }
            if (playerID == 1)
            {
                playerName = "Luigi";
            }

            // Inital setup
            DebugMode = debug;
            scaleSize = inputScaleSize;
            activetBrush = new TextureBrush (new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject(playerName + "Right00")));
            activetBrush.TranslateTransform(0, inputScaleSize);

            // Inital positioning and direction
            direction = "Right";
            posX = startPosX;
            posY = startPosY;
            if (startState > 0)
            {
                posY -= scaleSize;
            }
            sizeX = startSizeX;
            sizeY = startSizeY;
            isGrounded = isStartGrounded;

            // hitBox is slightly thinner
            hitBox = new Rectangle(posX + 5, posY, (int)(sizeX * 0.6875f), sizeY);
            recPosition = new Rectangle(posX, posY, sizeX, sizeY);
            fallDetect = new Rectangle(posX, posY + 1, sizeX, sizeY);

            this.drawingBrushColour = drawingBrushColour;

            state = startState;
            controllable = controllableInput;
        }

        // Alters Mario's position
        public void ChangePosition(int x, int y)
        {
            activetBrush.TranslateTransform(-(recPosition.X - x), -(recPosition.Y - y));
            hitBox.Location = new Point(x + 5, y);
            recPosition.Location = new Point(x, y);
            fallDetect.Location = new Point(x, y + 1);
        }
        // Only alters Mario's x position
        public void ChangePosition(int x)
        {
            activetBrush.TranslateTransform(-(recPosition.X - x), 0);
            hitBox.Location = new Point(x + 5, hitBox.Y);
            recPosition.Location = new Point(x, recPosition.Y);
            fallDetect.Location = new Point(x, fallDetect.Y);
        }

        public void Update(PaintEventArgs e)
        {
            // Prefix assignment
            if (poleState)
            {
                totalFrames = 0;
                if (direction == "Right")
                {
                    prefix = "Pole";
                    flipped = false;
                }
                else
                {
                    prefix = "Pole";
                    flipped = true;
                }
            }
            else
            {
                if (!specialActive)
                {
                    if (isGrounded)
                    {
                        if (moving)
                        {
                            totalFrames = 2;
                            prefix = "Right";
                            if (direction == "Right")
                            {
                                flipped = false;
                            }
                            else
                            {
                                flipped = true;
                            }
                        }
                        else
                        {
                            if (isCrouching)
                            {
                                totalFrames = 0;
                                prefix = "Crouch";
                                currentFrame = 0;
                                if (direction == "Right")
                                {
                                    flipped = false;
                                }
                                else
                                {
                                    flipped = true;
                                }
                            }
                            else
                            {
                                totalFrames = 0;
                                prefix = "Idle";
                                currentFrame = 0;
                                if (direction == "Right")
                                {
                                    flipped = false;
                                }
                                else
                                {
                                    flipped = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        totalFrames = 0;
                        currentFrame = 0;
                        prefix = "Jump";
                        if (direction == "Right")
                        {
                            flipped = false;
                        }
                        else
                        {
                            flipped = true;
                        }
                    }
                }
                else
                {
                    totalFrames = 0;
                    currentFrame = 0;
                    if (direction == "Right")
                    {
                        prefix = "Fire";
                        flipped = false;
                    }
                    else
                    {
                        prefix = "Fire";
                        flipped = true;
                    }
                    specialCounter++;
                    if (specialCounter == specialLength)
                    {
                        specialActive = false;
                        specialCounter = 0;
                    }
                }
            }
            // Animation handler
            if (frameCounter >= targetRate)
            {
                frameCounter = 0;
                if (boomerangEffect == false)
                {
                    if (currentFrame >= totalFrames)
                    {
                        boomerangEffect = true;
                        currentFrame--;
                    }
                    else
                    {
                        currentFrame++;
                    }
                }
                else
                {
                    if (currentFrame == 0)
                    {
                        boomerangEffect = false;
                    }
                    else
                    {
                        currentFrame--;
                    }
                }
                if (currentFrame < 0)
                {
                    currentFrame = 0;
                }
            }
            else
            {
                frameCounter++;
            }

            if (poleState && isGrounded)
            {
                currentFrame = 1;
            }

            // Debug Mode colouring
            if (DebugMode)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), fallDetect);
                e.Graphics.FillRectangle(new SolidBrush(Color.Green), hitBox);
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), recPosition);
            }

            recPosition.Height = activetBrush.Image.Height;
            fallDetect.Height = activetBrush.Image.Height;
            hitBox.Height = activetBrush.Image.Height;
            sizeY = activetBrush.Image.Height;

            // Final brush setup
            float tBrushX = activetBrush.Transform.OffsetX;
            float tBrushY = activetBrush.Transform.OffsetY;
            string name = playerName + prefix + state.ToString() + currentFrame;
            if(state == 3 || state == 4)
            {
                // Star colour loop
                name = playerName + prefix + state.ToString() + currentFrame + starState;
                starSubCounter++;
                if (starSubCounter == 10)
                {
                    starLength++;
                    if (starState == 3)
                    {
                        starState = 0;
                    }
                    else
                    {
                        starState++;
                    }
                    starSubCounter = 0;
                }
                if(starLength == 300)
                {
                    SetState(memoryState);
                    starLength = 0;
                }
            }
            Bitmap image = new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject(name));
            if (flipped)
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            image.MakeTransparent(Color.White);
            activetBrush = new TextureBrush(image);
            activetBrush.TranslateTransform(tBrushX, tBrushY);

            // Draws Mario element
            e.Graphics.FillRectangle(activetBrush, recPosition);
        }

        public void SetState(int newState)
        {
            if (newState != 5) // 5 - Add 1 life
            {
                if (state == 0)
                {
                    activetBrush.TranslateTransform(0, scaleSize);
                }
                if (newState > 2)
                {
                    // memoryState holds the state to refer back to
                    memoryState = state;
                }
                state = newState;
            }
            else
            {
                addLife = true;
            }
        }

        public void setRun(bool newRun)
        {
            // Makes animation quicker if running
            if (newRun)
            {
                targetRate = 12;
            }
            else
            {
                targetRate = 20;
            }
            running = newRun;
        }

        // Get / Set functions:

        public void SetGrounded(bool state)
        {
            isGrounded = state;
        }

        public bool GetGrounded()
        {
            return isGrounded;
        }

        public float GetFltSpeed()
        {
            return fltSpeed;
        }

        public float GetFltXVel()
        {
            return fltXVel;
        }

        public double GetFltYVel()
        {
            return fltYVel;
        }

        public void SetFltSpeed(float speed)
        {
            fltSpeed = speed;
        }

        public void SetFltXVel(float xVel)
        {
            fltXVel = xVel;
        }

        public void SetFltYVel(double yVel)
        {
            fltYVel = yVel;
        }

        public void SetDirection(string newDirection)
        {
            direction = newDirection;
        }

        public string GetDirection()
        {
            return direction;
        }

        public Rectangle GetRecPosition()
        {
            return recPosition;
        }

        public Rectangle GetHitBox()
        {
            return hitBox;
        }

        public Rectangle GetFallDetectRec()
        {
            return fallDetect;
        }

        public Brush GetBrushColour()
        {
            return drawingBrushColour;
        }

        public int GetSizeX()
        {
            return sizeX;
        }

        public void SetSizeX(int newSizeX)
        {
            sizeX = newSizeX;
        }

        public int GetSizeY()
        {
            return sizeY;
        }

        public void SetSizeY(int newSizeY)
        {
            sizeY = newSizeY;
        }

        public void setMoving(bool newMove)
        {
            moving = newMove;
        }

        public int GetState()
        {
            return state;
        }

        public void setMemoryState(int newState)
        {
            memoryState = newState;
        }

        public bool getLife()
        {
            return addLife;
        }

        public void setLife(bool newLife)
        {
            addLife = newLife;
        }

        public bool GetControllable()
        {
            return controllable;
        }

        public void SetControllable(bool newControl)
        {
            controllable = newControl;
        }

        public void setCrouch(bool newCrouch)
        {
            isCrouching = newCrouch;
        }

        public bool getCrouch()
        {
            return isCrouching;
        }

        public void SetPoleState(bool newPole)
        {
            poleState = newPole;
        }

        public bool GetPoleState()
        {
            return poleState;
        }

        public void setRecBox(Rectangle newRec)
        {
            recPosition = newRec;
        }

        public void setSpecial(bool activeSpecial)
        {
            specialActive = activeSpecial;
        }

        public void stopStar()
        {
            state = memoryState;
        }

        public bool getRunning()
        {
            return running;
        }
    }
}
