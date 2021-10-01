namespace GameEngine
{
    public class Drawing : AbstractGame
    {
        //why do you make me do this
        public int[][] MarioCharacter = new int[17][]
        {
            new int[12]{ 0, 0 , 0 , 1, 1, 1, 1, 1, 0, 0, 0, 0},
            new int[12]{ 0 , 0 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 0},
            new int[12]{ 0 , 0 , 3 , 3 , 3 , 2 , 2 , 3 , 2 , 0 , 0 , 0},
            new int[12]{ 0 , 3 , 2 , 3 , 2 , 2 , 2 , 3 , 2 , 2 , 2 , 0},
            new int[12]{ 0 , 3 , 2 , 3 , 3 , 2 , 2 , 2 , 3 , 2 , 2 , 2},
            new int[12]{ 0 , 3 , 3 , 2 , 2 , 2 , 2 , 3 , 3 , 3 , 3 , 0},
            new int[12]{ 0 , 0 , 0 , 2 , 2 , 2 , 2 , 2 , 2 , 2 , 0 , 0},
            new int[12]{ 0 , 0 , 3 , 3 , 1 , 3 , 3 , 3 , 0 , 0 , 0 , 0},
            new int[12]{ 0 , 3 , 3 , 3 , 1 , 3 , 3 , 1 , 3 , 3 , 3 , 0},
            new int[12]{ 3 , 3 , 3 , 3 , 1 , 1 , 1 , 1 , 3 , 3 , 3 , 3}, 
            new int[12]{ 2 , 2 , 3 , 1 , 2 , 1 , 1 , 2 , 1 , 3 , 2 , 2},
            new int[12]{ 2 , 2 , 2 , 1 , 1 , 1 , 1 , 1 , 1 , 2 , 2 , 2},
            new int[12]{ 2 , 2 , 2 , 1 , 1 , 1 , 1 , 1 , 1 , 2 , 2 , 2},
            new int[12]{ 2 , 2 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 2 , 2},
            new int[12]{ 0 , 0 , 1 , 1 , 1 , 0 , 0 , 1 , 1 , 1 , 0 , 0},
            new int[12]{ 0 , 3 , 3 , 3 , 0 , 0 , 0 , 0 , 3 , 3 , 3 , 0},
            new int[12]{ 3 , 3 , 3 , 3 , 0 , 0 , 0 , 0 , 3 , 3 , 3 , 3}

        };

        //marios color pallet
        public Color[] MarioColorindex = new Color[4]
{
            Color.Alpha,
            Color.Red,
            new Color(252, 158, 91),
            new Color(196, 99, 1)
};
        //luigis color pallet
        public Color[] LuigiColorIndex = new Color[4]
{
            Color.Alpha,
            Color.Green,
            new Color(252, 158, 91),
            new Color(196, 99, 1)
};
        public override void GameStart()
        {
            //Everything that has to happen when the game starts happens here.
            //F.e. initializing objects.
        }

        public override void GameEnd()
        {
            //Clean up unmanaged objects here (F.e. bitmaps & fonts)

            //For example:
            //m_Bitmap.Dispose();
            //m_Font.Dispose();
        }

        public override void Update()
        {
            //Update everything here.
            //F.e. get input, move objects, etc...
            //For example:
            //float deltaTime = GAME_ENGINE.GetDeltaTime();
            //bool isDown = GAME_ENGINE.GetKeyDown(Key.Right);
        }
        Vector2 screensize;
        Vector2 CurrentPosition;
        int MaxX;
        public override void Paint()
        {
            //reset value for repaint
            CurrentPosition = new Vector2();
            MaxX = 0;
            number = 1;
            screensize = new Vector2(GAME_ENGINE.GetScreenWidth(), GAME_ENGINE.GetScreenHeight());

            
            GAME_ENGINE.SetColor(Color.Black);
            
            
            // name
            string name = "1. justin van diggelen";
            GAME_ENGINE.DrawString(name, GetRect(name.Length * 7, 30, true));


            DrawNumber();
            drawFlag();


            DrawNumber();
            DrawCheckerBoard();

            DrawNumber();
            DrawHouse();

            DrawNumber();
            drawStopLight();


            DrawNumber();
            DrawCube();

            DrawNumber();
            DrawMario();

            DrawNumber();
            DrawLuigi();
        }


        int number = 0;

        /// <summary>
        /// automaticly increases the number and draws to the screen
        /// </summary>
        void DrawNumber()
        {
           
            GAME_ENGINE.SetColor(Color.Black);
            number++;
            string name = $"{number}. ";
            GAME_ENGINE.DrawString(name, GetRect(name.Length * 10, 30));
        }


        const int AFTERNUMBEROFFSET = 25;
        int Xoffset => AFTERNUMBEROFFSET + CurrentPosition.X;

        const int FlagLength = 25;
        const int FlagHeight = 100;
        /// <summary>
        /// draws a flag
        /// </summary>
        void drawFlag()
        {

            //draws the mars flag
            GAME_ENGINE.SetColor(255, 0, 0);
            GAME_ENGINE.FillRectangle(AFTERNUMBEROFFSET, CurrentPosition.Y, FlagLength, FlagHeight);
            GAME_ENGINE.SetColor(0, 255, 0);
            GAME_ENGINE.FillRectangle(AFTERNUMBEROFFSET + FlagLength, CurrentPosition.Y, FlagLength, FlagHeight);
            GAME_ENGINE.SetColor(0, 0, 255);
            GAME_ENGINE.FillRectangle(AFTERNUMBEROFFSET + FlagLength * 2, CurrentPosition.Y, FlagLength, FlagHeight);
            GAME_ENGINE.SetColor(Color.Black);

            if (AFTERNUMBEROFFSET + FlagLength * 2 > MaxX)
                MaxX = AFTERNUMBEROFFSET + FlagLength * 2;

            AddYOffset(FlagHeight);
        }

        const int CHECKERSIZE = 25;
        void DrawCheckerBoard()
        {

            bool UseBlack = false;
            // loop through each square
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    UseBlack = !UseBlack;
                    GAME_ENGINE.SetColor(UseBlack ? Color.Black : Color.White);
                    GAME_ENGINE.FillRectangle(Xoffset + x * CHECKERSIZE, CurrentPosition.Y + y * CHECKERSIZE, CHECKERSIZE, CHECKERSIZE);
                }

            }
            //draw black border
            GAME_ENGINE.SetColor(Color.Black);
            GAME_ENGINE.DrawRectangle(Xoffset, CurrentPosition.Y, CHECKERSIZE * 3, CHECKERSIZE * 3, 2);


            //set a extra maxX if nessery, prevent overlapping
            int TotalSizeX = Xoffset + CHECKERSIZE * 3;
            if (TotalSizeX > MaxX)
                MaxX = TotalSizeX;
            //add y offset for next drawing
            AddYOffset(CHECKERSIZE * 3);
        }


        void DrawHouse()
        {
           
            int HouseLength = 50;
            int houseHeight = 75;
            int roofHeight = 50;

            //draw roof
            GAME_ENGINE.DrawLine(Xoffset, CurrentPosition.Y + roofHeight, Xoffset + HouseLength / 2, CurrentPosition.Y);
            GAME_ENGINE.DrawLine(Xoffset + HouseLength, CurrentPosition.Y + roofHeight, Xoffset + HouseLength / 2, CurrentPosition.Y);

            //draw base
            GAME_ENGINE.DrawRectangle(Xoffset, CurrentPosition.Y + roofHeight, HouseLength, houseHeight);

            //add y offset for next drawing
            AddYOffset(houseHeight + roofHeight);

            //set a extra maxX if nessery, prevent overlapping
            int TotalSizeX = Xoffset + HouseLength;
            if (TotalSizeX > MaxX)
                MaxX = TotalSizeX;
        }

        private void drawStopLight()
        {
            int baseheight = 150;
            int baseWith = 50;
            int PoleHeight = 50;

            //the background

            GAME_ENGINE.SetColor(Color.Gray);
            GAME_ENGINE.FillRectangle(Xoffset, CurrentPosition.Y, baseWith, baseheight);
            GAME_ENGINE.FillRectangle(Xoffset + (baseWith / 4), CurrentPosition.Y + baseheight, 25, PoleHeight);

            int EllipseX = Xoffset + baseWith / 2;
            GAME_ENGINE.SetColor(Color.Red);

            GAME_ENGINE.FillEllipse(EllipseX, CurrentPosition.Y + baseheight / 4, baseWith / 3, baseWith / 3);

            GAME_ENGINE.SetColor(Color.Yellow);
            GAME_ENGINE.FillEllipse(EllipseX, CurrentPosition.Y + baseheight / 4 * 2, baseWith / 3, baseWith / 3);

            GAME_ENGINE.SetColor(Color.Green);
            GAME_ENGINE.FillEllipse(EllipseX, CurrentPosition.Y + baseheight / 4 * 3, baseWith / 3, baseWith / 3);


            //set a extra maxX if nessery, prevent overlapping
            if (Xoffset + baseWith > MaxX)
                MaxX = Xoffset + baseWith;

            AddYOffset(baseheight + PoleHeight);
        }

        private void DrawCube()
        {
            int Size = 150;
            int radius = 10;

            GAME_ENGINE.SetColor(Color.White);
            GAME_ENGINE.FillRoundedRectangle(Xoffset, CurrentPosition.Y, Size, Size, radius, radius);
            GAME_ENGINE.SetColor(Color.Black);
            GAME_ENGINE.DrawRoundedRectangle(Xoffset, CurrentPosition.Y, Size, Size, radius, radius, 2);

            Size /= 4;

            GAME_ENGINE.FillEllipse(Xoffset + Size, CurrentPosition.Y + Size, Size / 2, Size / 2);
            GAME_ENGINE.FillEllipse(Xoffset + Size * 2, CurrentPosition.Y + Size * 2, Size / 2, Size / 2);
            GAME_ENGINE.FillEllipse(Xoffset + Size * 3, CurrentPosition.Y + Size * 3, Size / 2, Size / 2);

            //set a extra maxX if nessery, prevent overlapping
            Size *= 4;
            if (Xoffset + Size > MaxX)
                MaxX = Xoffset + Size;

            AddYOffset(Size * 4);
        }
        /// <summary>
        /// draws a mario figure on the screen
        /// </summary>
        private void DrawMario()
        {
            int tileSize = 10;

            GAME_ENGINE.SetColor(Color.Red);
            GAME_ENGINE.DrawString("mario",Xoffset,CurrentPosition.Y, 50, 20);

            CurrentPosition.Y += 20;


            //loop trough each index pixel 
            for (int y = 0; y < MarioCharacter.Length; y++)
            {
                int[] colors = MarioCharacter[y];
                for (int X = 0; X < colors.Length; X++)
                {
                    //get the color from the table and draw
                    Color color = MarioColorindex[colors[X]];
                    GAME_ENGINE.SetColor(color);
                    GAME_ENGINE.FillRectangle(Xoffset + X * tileSize, CurrentPosition.Y + y * tileSize, tileSize, tileSize);
                }
            }

            AddYOffset(MarioCharacter.Length * tileSize);


        }
        /// <summary>
        /// draws a luigi figure on the screen
        /// </summary>
        private void DrawLuigi()
        {
            int tileSize = 10;

            GAME_ENGINE.SetColor(Color.Green);
            GAME_ENGINE.DrawString("luigi", Xoffset, CurrentPosition.Y, 50, 20);

            CurrentPosition.Y += 20;


            //loop trough each index pixel 
            for (int y = 0; y < MarioCharacter.Length; y++)
            {
                int[] colors = MarioCharacter[y];
                for (int X = 0; X < colors.Length; X++)
                {
                    //get the color from the table and draw
                    Color color = LuigiColorIndex[colors[X]];
                    GAME_ENGINE.SetColor(color);
                    GAME_ENGINE.FillRectangle(Xoffset + (colors.Length - X) * tileSize, CurrentPosition.Y + y * tileSize, tileSize, tileSize);
                }
            }
            //add y offset for next drawing
            AddYOffset(LuigiColorIndex.Length * tileSize);


        }
        /// <summary>
        /// resets a position so that noving will overlap
        /// </summary>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        /// <param name="moveNext"></param>
        /// <returns></returns>
        Rectanglef GetRect(int sizeX, int sizeY, bool moveNext = false)
        {
            // check if the draw will be out of bounds
            if (CurrentPosition.Y + sizeY + 50 > screensize.Y)
            {
                //reset the curent position to the top and move it so it does not cover up other drawings
                CurrentPosition = new Vector2(MaxX, 0);

            }

            //keep track of the biggest drawing 
            if (sizeX > MaxX)
                MaxX = sizeX;

            //create the rect
            Rectanglef rect = new Rectanglef();

            rect.Width = sizeX;
            rect.Height = sizeY;

            rect.X = CurrentPosition.X;
            rect.Y = CurrentPosition.Y;

            // move for the next graphic
            if (moveNext)
                AddYOffset(sizeY);

            return rect;

        }

        const int ExtraOffset = 50;
        void AddYOffset(int amount)
        {
            CurrentPosition.Y += amount + ExtraOffset;
        }
    }
}
