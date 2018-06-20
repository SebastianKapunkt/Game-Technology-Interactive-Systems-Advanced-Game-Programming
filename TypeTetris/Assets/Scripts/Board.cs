public class Board
{
    public int rows { get; internal set; }
    public int columns { get; internal set; }

    public int current { get; internal set; }
    public int middleField { get; internal set; }

    private int[,] field;

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

    private void insertStone(int[,] stone)
    {
        current++;
    }

    private bool isEmpty(int row, int column)
    {
        return field[row, column] == 0;
    }
}
