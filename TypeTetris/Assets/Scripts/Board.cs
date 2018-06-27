public class Board
{
    public int rows { get; internal set; }
    public int columns { get; internal set; }

    public int current { get; internal set; }
    public int middleField { get; internal set; }

    public int[,] field { get; internal set; }

    public Board(int rows, int columns)
    {
        this.rows = rows;
        if (columns % 2 == 0)
        {
            //when even make odd
            this.columns = columns + 1;
        }
        else
        {
            this.columns = columns;
        }
        middleField = columns / 2 + 1;
        createField();
    }

    private void createField()
    {
        field = new int[rows, columns];
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                field[r, c] = 0;
            }
        }
    }

    public void insertBlock(int[,] stone)
    {
        current++;
        int mostTopFilledRowNumber = BoardUtils.getMostTopFilledRowNumber(stone);
        int stoneLeft = 0;
        int stoneRight = 0;
        BoardUtils.getStoneBorders(stone, out stoneLeft, out stoneRight);
        int spaceToLeft = BoardUtils.calculateSpaceToLeft(field.GetLength(1), stoneLeft, stoneRight);

        int marginLeft = spaceToLeft;
        int fromTop = 0;
        for (int r = mostTopFilledRowNumber; r < stone.GetLength(0); r++)
        {
            for (int c = stoneLeft; c <= stoneRight; c++)
            {
                if (stone[r, c] == 1)
                {
                    field[fromTop, marginLeft] = current;
                }
                marginLeft++;
            }
            fromTop++;
            marginLeft = spaceToLeft;
        }
    }

    

    private bool isEmpty(int row, int column)
    {
        return field[row, column] == 0;
    }
}
