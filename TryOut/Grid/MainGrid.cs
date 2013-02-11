﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryOut.Grid
{
    class MainGrid
    {
        int gridWidth, gridHeigth;
        int gridCellSide;
        int gridCellX, gridCellY;
        int xCells, yCells;
        GridCell[,] grid;

        public Graphics graphics;

        public MainGrid(Graphics g/*int width, int heigth*/)
        {
            Console.WriteLine("Initializin Grid");

            graphics = g;

            gridCellSide = 30;
            gridCellX = 0;
            gridCellY = 0;

            gridWidth = 300; //width;
            gridHeigth = 300; //heigth;

            xCells = gridWidth / gridCellSide;
            yCells = gridHeigth / gridCellSide;
            
            grid = new GridCell[xCells,yCells];

            for (int i = 0; i < xCells; i++)
            {
                for (int j = 0; j < yCells; j++)
                {
                    grid[i, j] = new GridCell(gridCellSide,gridCellX, gridCellY);
                    gridCellY += gridCellSide;
                }
                gridCellX += gridCellSide;
                gridCellY = 0;
            }

            grid[4, 4] = new WallCell(gridCellSide, gridCellX + (gridCellSide * 5), gridCellY + (gridCellSide * 5));
            grid[4, 5] = new WallCell(gridCellSide, gridCellX + (gridCellSide * 5), gridCellY + (gridCellSide * 6));
            grid[5, 4] = new WallCell(gridCellSide, gridCellX + (gridCellSide * 6), gridCellY + (gridCellSide * 5));
            grid[5, 5] = new WallCell(gridCellSide, gridCellX + (gridCellSide * 6), gridCellY + (gridCellSide * 6));
        }

        public void Draw()
        {
            int i = 0;
            Console.WriteLine("Drawing Grid");
            foreach (GridCell cell in grid)
            {
                if (cell.isWall)
                {
                    cell.DrawCell(graphics, Color.Black);
                }
                Console.WriteLine("Drawing Cell" + i);
                cell.DrawCell(graphics, Color.White);
                i++;
            }
        }

    }
}
