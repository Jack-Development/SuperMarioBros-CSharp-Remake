using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using System.Reflection;

namespace SuperMarioBros
{
    class Block
    {
        // Block variables
        public string ID;
        public string name;
        public bool solid;
        public bool breakable;
        public bool background;
        public bool isGoal;
        public int contentID;
        public bool isContainer;
        public bool isHit;
        public bool isSemiSolid = false;
        public string contents;
        bool canBeHit;
        int HP = 1;
        bool spawner;
        string spawnEntity;

        public int x;
        public int y;
        public float offset;
        public int scaleSize;

        public SolidBrush colour;
        PaintEventArgs e;

        List<string[]> LookUp;
        List<Bitmap> sprite = null;
        List<TextureBrush> tBrush;
        List<Bitmap> hitSprite = null;
        List<TextureBrush> hittBrush;

        ResourceManager resourceManager;
        bool active = true;

        bool animated;
        int animationFrames = 0;
        int currentFrame = 0;
        bool frameBool;

        bool addScore;

        float bounceHeight;
        float previousBounceHeight;
        bool bounceBack;

        bool DebugMode;

        Rectangle blockArea;

        public Block(string giveID, List<string[]> LookUpPass, int startPosX, int startPosY, float offsetIn, int scaleSizeIn, PaintEventArgs eIn, ResourceManager resourceManagerIn, bool Debug)
        {
            // Inital setup
            DebugMode = Debug;
            resourceManager = resourceManagerIn;
            ID = giveID;
            LookUp = LookUpPass;
            x = startPosX;
            y = startPosY;
            offset = offsetIn;
            scaleSize = scaleSizeIn;
            e = eIn;
            StartUp();
        }

        void StartUp()
        {
            // Sprite block allocation
            frameBool = false;
            // Set background boolean
            background = (Convert.ToInt32(LookUp[Convert.ToInt32(ID)][4]) != 0);
            // If there is a resource with the block name
            if ((Bitmap)Properties.Resources.ResourceManager.GetObject(LookUp[Convert.ToInt32(ID)][1] + "0") != null)
            {
                tBrush = new List<TextureBrush>();
                sprite = new List<Bitmap>();
                sprite.Add(new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject(LookUp[Convert.ToInt32(ID)][1] + "0")));
                foreach (Bitmap bi in sprite)
                {
                        for (int i = 0; i < bi.Height; i++)
                        {
                            for (int j = 0; j < bi.Width; j++)
                            {
                                Color color = bi.GetPixel(i, j);
                                if (color == Color.FromArgb(255, 255, 255))
                                {
                                    // Sets specific pixels to be the set background color (Allows the same resources to be used with different backgrounds)
                                    bi.SetPixel(i, j, Color.FromArgb(Convert.ToInt32(LookUp[Convert.ToInt32(ID)][7]), Convert.ToInt32(LookUp[Convert.ToInt32(ID)][8]), Convert.ToInt32(LookUp[Convert.ToInt32(ID)][9])));
                                }
                            }
                        }
                }
                tBrush.Add(new TextureBrush(sprite[0]));
                tBrush[0].WrapMode = System.Drawing.Drawing2D.WrapMode.Clamp;
                tBrush[0].TranslateTransform(x * scaleSize - offset, y * scaleSize);
                tBrush[0].ScaleTransform(scaleSize / 32, scaleSize / 32);
                e.Graphics.FillRectangle(tBrush[0], new Rectangle((x * scaleSize) - Convert.ToInt32(offset), y * scaleSize, 1 * scaleSize, 1 * scaleSize));
                background = false;

                // If there is a hit image then the item can be hit
                if ((Bitmap)Properties.Resources.ResourceManager.GetObject(LookUp[Convert.ToInt32(ID)][12]) != null)
                {
                    hittBrush = new List<TextureBrush>();
                    canBeHit = true;
                }
            }
            // Cross-reference with lookup
            name = LookUp[Convert.ToInt32(ID)][1];
            solid = Convert.ToInt32(LookUp[Convert.ToInt32(ID)][2]) != 0;
            colour = new SolidBrush(Color.FromArgb(Convert.ToInt32(LookUp[Convert.ToInt32(ID)][7]), Convert.ToInt32(LookUp[Convert.ToInt32(ID)][8]), Convert.ToInt32(LookUp[Convert.ToInt32(ID)][9])));
            if (background == false)
            {
                // Sets non-background variables
                breakable = Convert.ToInt32(LookUp[Convert.ToInt32(ID)][3]) != 0;
                isGoal = Convert.ToInt32(LookUp[Convert.ToInt32(ID)][5]) != 0;
                contentID = Convert.ToInt32(LookUp[Convert.ToInt32(ID)][6]);
                isContainer = Convert.ToInt32(LookUp[Convert.ToInt32(ID)][10]) != 0;
                if (isContainer)
                {
                    // To reference to entity
                    contents = LookUp[Convert.ToInt32(ID)][11];
                }
                // If animated
                if (LookUp[Convert.ToInt32(ID)][13] == "1")
                {
                    animated = true;
                    animationFrames = Convert.ToInt32(LookUp[Convert.ToInt32(ID)][14]);
                }
                if (LookUp[Convert.ToInt32(ID)][1] == "InvisQuestionBlock")
                {
                    isSemiSolid = true;
                }
                if (Convert.ToInt32(LookUp[Convert.ToInt32(ID)][0]) == 5)
                {
                    // Multiple block hits to get multiple coins
                    HP = 5;
                }

                blockArea = new Rectangle((x * scaleSize) - Convert.ToInt32(offset), y * scaleSize, scaleSize, scaleSize);

                // If the hit sprite exists
                if ((Bitmap)Properties.Resources.ResourceManager.GetObject(LookUp[Convert.ToInt32(ID)][12]) != null)
                {
                    hitSprite = new List<Bitmap>();
                    hitSprite.Add(new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject(LookUp[Convert.ToInt32(ID)][12])));
                    foreach (Bitmap bi in hitSprite)
                    {
                            for (int i = 0; i < bi.Height; i++)
                            {
                                for (int j = 0; j < bi.Width; j++)
                                {
                                    Color color = bi.GetPixel(i, j);
                                    if (color == Color.FromArgb(255, 255, 255))
                                    {
                                        // Sets specific pixels to be the set background color (Allows the same resources to be used with different backgrounds)
                                        bi.SetPixel(i, j, Color.FromArgb(Convert.ToInt32(LookUp[Convert.ToInt32(ID)][7]), Convert.ToInt32(LookUp[Convert.ToInt32(ID)][8]), Convert.ToInt32(LookUp[Convert.ToInt32(ID)][9])));
                                    }
                                }
                            }
                    }
                    hittBrush.Add(new TextureBrush(hitSprite[0]));
                    hittBrush[0].WrapMode = System.Drawing.Drawing2D.WrapMode.Clamp;
                    hittBrush[0].TranslateTransform(x * scaleSize - offset, y * scaleSize);
                    hittBrush[0].ScaleTransform(scaleSize / 32, scaleSize / 32);
                }

                // Adds animated frames to list
                if (animated)
                {
                    for (int i = 1; i < animationFrames + 1; i++)
                    {
                        sprite.Add(new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject(LookUp[Convert.ToInt32(ID)][1] + i.ToString())));
                        foreach (Bitmap bi in sprite)
                        {
                            for (int k = 0; k < bi.Height; k++)
                            {
                                for (int j = 0; j < bi.Width; j++)
                                {
                                    Color color = bi.GetPixel(k, j);
                                    if (color == Color.FromArgb(255, 255, 255))
                                    {
                                        // Sets specific pixels to be the set background color (Allows the same resources to be used with different backgrounds)
                                        bi.SetPixel(k, j, Color.FromArgb(Convert.ToInt32(LookUp[Convert.ToInt32(ID)][7]), Convert.ToInt32(LookUp[Convert.ToInt32(ID)][8]), Convert.ToInt32(LookUp[Convert.ToInt32(ID)][9])));
                                    }
                                }
                            }
                        }
                        tBrush.Add(new TextureBrush(sprite[i]));
                        tBrush[i].WrapMode = System.Drawing.Drawing2D.WrapMode.Clamp;
                        tBrush[i].TranslateTransform(x * scaleSize - offset, y * scaleSize);
                        tBrush[i].ScaleTransform(scaleSize / 32, scaleSize / 32);
                    }
                }
            }
            else
            {
                // If none pass then set to be the default colour
                e.Graphics.FillRectangle(colour, new Rectangle((x * scaleSize) - Convert.ToInt32(offset), y * scaleSize, 1 * scaleSize, 1 * scaleSize));
            }
            if (animated) {
                bounceBack = Convert.ToInt32(LookUp[Convert.ToInt32(ID)][15]) != 0;
            }
            // Spawner setup
            spawner = Convert.ToInt32(LookUp[Convert.ToInt32(ID)][16]) != 0;
            if (spawner)
            {
                spawnEntity = LookUp[Convert.ToInt32(ID)][17];
            }
        }

        public void setHit(bool newHit)
        {
            // When the block is hit
            HP--;
            if (HP == 0)
            {
                isHit = newHit;
                if ((Bitmap)Properties.Resources.ResourceManager.GetObject(LookUp[Convert.ToInt32(ID)][12]) == null)
                {
                    // Get rid of the block
                    solid = false;
                    sprite = null;
                    colour = new SolidBrush(Color.FromArgb(Convert.ToInt32(LookUp[Convert.ToInt32(ID)][7]), Convert.ToInt32(LookUp[Convert.ToInt32(ID)][8]), Convert.ToInt32(LookUp[Convert.ToInt32(ID)][9])));
                }
            }
        }
        public void Update(PaintEventArgs eStore, float newOffset)
        {
            // Update the block position with the new offset
            blockArea = new Rectangle((x * scaleSize) - Convert.ToInt32(newOffset), (y * scaleSize) - (int)bounceHeight, 1 * scaleSize, 1 * scaleSize);
            eStore.Graphics.FillRectangle(colour, new Rectangle((x * scaleSize) - Convert.ToInt32(newOffset), (y * scaleSize), 1 * scaleSize, 1 * scaleSize));
            if (background == false)
            {
                if (sprite != null)
                {
                    // Fills in background
                    if (isContainer)
                    {
                        eStore.Graphics.FillRectangle(colour, blockArea);
                    }
                    // Offsets sprites
                    foreach (TextureBrush tBrush in tBrush)
                    {
                        tBrush.TranslateTransform(Convert.ToInt32(-(Convert.ToInt32(newOffset) - offset)), -(bounceHeight - previousBounceHeight), System.Drawing.Drawing2D.MatrixOrder.Append);
                    }
                    if (canBeHit)
                    {
                        foreach (TextureBrush tBrush in hittBrush)
                        {
                            tBrush.TranslateTransform(Convert.ToInt32(-(Convert.ToInt32(newOffset) - offset)), -(bounceHeight - previousBounceHeight), System.Drawing.Drawing2D.MatrixOrder.Append);
                        }
                    }
                    // Draws sprites
                    if (!isHit)
                    {
                        eStore.Graphics.FillRectangle(tBrush[currentFrame], blockArea);
                    }
                    else
                    {
                        eStore.Graphics.FillRectangle(hittBrush[0], blockArea);
                    }
                }
                else
                {
                    eStore.Graphics.FillRectangle(colour, blockArea);
                }
                previousBounceHeight = bounceHeight;
                if (bounceHeight > 0)
                {
                    bounceHeight -= 0.45f;
                }
                else if (bounceHeight < 0)
                {
                    bounceHeight = 0;
                }
            }
            else
            {
                eStore.Graphics.FillRectangle(colour, blockArea);
            }
            // Updates stored offset for next update
            offset = Convert.ToInt32(newOffset);
        }

        public Entity spawnItem(string ID, List<string[]> entityLookUpPass, float entityOffset, int MarioState)
        {
            // Creates spawned item
            if(ID == "Mushroom")
            {
                if(MarioState > 0 && MarioState != 3)
                {
                    return new Entity("FireFlower", (int)(x * scaleSize), (int)((y * scaleSize)), 1 * scaleSize, 1 * scaleSize, true, scaleSize, entityOffset, entityLookUpPass, 1, 0, DebugMode);
                }
                else
                {
                    return new Entity(ID, (int)(x * scaleSize), (int)((y * scaleSize)), 1 * scaleSize, 1 * scaleSize, true, scaleSize, entityOffset, entityLookUpPass, 1, 0, DebugMode);
                }
            }
            else
            {
                return new Entity(ID, (int)(x * scaleSize), (int)((y * scaleSize)), 1 * scaleSize, 1 * scaleSize, true, scaleSize, entityOffset, entityLookUpPass, 1, 0, DebugMode);
            }
        }

        // Allows for brick bounce if state is correct
        public void Bounce()
        {
            bounceHeight = (int)(scaleSize * 0.5f);
        }

        // Deletes block
        public void delete(List<string[]> entityLookUpPass, float entityOffset)
        {
            active = false;
            addScore = true;
            sprite = null;
            colour = new SolidBrush(Color.FromArgb(Convert.ToInt32(LookUp[Convert.ToInt32(ID)][7]), Convert.ToInt32(LookUp[Convert.ToInt32(ID)][8]), Convert.ToInt32(LookUp[Convert.ToInt32(ID)][9])));
            solid = false;
        }

        // Creates spawn entity
        public Entity spawnControl(List<string[]> entityLookUp)
        {
            spawner = false;
            return (new Entity(spawnEntity, (x * scaleSize), (y * scaleSize), 1 * scaleSize, 1 * scaleSize, true, scaleSize, offset, entityLookUp, 0, 0, DebugMode));
        }

        // Get / Set functions:

        public bool isSpawner()
        {
            return spawner;
        }

        public string getContents()
        {
            return contents;
        }

        public bool getSemiSolid()
        {
            return isSemiSolid;
        }

        public void setSemiSolid(bool newSolid)
        {
            isSemiSolid = newSolid;
        }

        public bool getBreakable()
        {
            return breakable;
        }

        public bool getScore()
        {
            return addScore;
        }

        public void setScore(bool newScore)
        {
            addScore = newScore;
        }

        public bool checkIsGoal()
        {
            return isGoal;
        }

        public bool isActive()
        {
            return active;
        }

        public bool getAnimated()
        {
            return animated;
        }

        public void setCurrentFrame(int setFrame)
        {
            currentFrame = setFrame;
        }

        public void setSolid(bool newSolid)
        {
            solid = newSolid;
        }

        public int getCurrentFrame()
        {
            return currentFrame;
        }

        public int getTotalFrames()
        {
            return animationFrames;
        }

        public string GetName()
        {
            return name;
        }

        public bool isSolid()
        {
            return solid;
        }

        public bool getIsContainer()
        {
            return isContainer;
        }

        public Rectangle getRec()
        {
            return blockArea;
        }

        public int getSize()
        {
            return (1 * scaleSize);
        }

        public bool getBounce()
        {
            return bounceBack;
        }

        public void setFrameBool(bool newFrameBool)
        {
            frameBool = newFrameBool;
        }

        public bool getFrameBool()
        {
            return frameBool;
        }

        public bool getHit()
        {
            return isHit;
        }

        public int getX()
        {
            return x * scaleSize;
        }

        public int getY()
        {
            return y * scaleSize;
        }
    }
}
