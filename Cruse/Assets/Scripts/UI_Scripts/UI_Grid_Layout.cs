using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Grid_Layout : LayoutGroup
{

    //public int rows;
    //public int cols;
    public Vector2 cellSize;
    public Vector2 spacing;
    public RectTransform btn;

    
    public override void CalculateLayoutInputHorizontal()
    {
        
        base.CalculateLayoutInputHorizontal();
        btn = rectChildren[0];
        float parentWith = rectTransform.rect.width;
        float parentHight = rectTransform.rect.height;

        cellSize = new Vector2(btn.rect.width, btn.rect.height);

        float btnWidth = btn.rect.width;
        float btnHeight = btn.rect.height;

        int numOfButtonsPerRow;
        numOfButtonsPerRow = (int)Mathf.Floor((parentWith - (padding.left * 2)) / (btnWidth + (spacing.x))); 

        int cols = numOfButtonsPerRow;

        int colCount = 0;
        int rowCount = 0;

        for(int i = 0; i < rectChildren.Count; i++)
        {
            if(cols == 0)
            {
                rowCount = 0;
                colCount = i;
            }
            else
            {
                rowCount = i / cols;
                colCount = i % cols;
            }
            

            var item = rectChildren[i];

            var xPos = (cellSize.x * colCount) + (spacing.x * colCount) + padding.left;
            var yPos = (cellSize.y * rowCount) + (spacing.y * rowCount) + padding.top;

            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 1, yPos, cellSize.y);
        }

        //use this code if you want the size of buttons to dynamicaly change size to fit their container.
        //float sqrRt = Mathf.Sqrt(transform.childCount);
        //rows = Mathf.CeilToInt(sqrRt);
        //cols = Mathf.CeilToInt(sqrRt);

        //float parentWith = rectTransform.rect.width;
        //float parentHight = rectTransform.rect.height;

        //float cellWidth = (parentWith / (float)cols) - ((spacing.x / (float)cols) * 2) - (padding.left / (float)cols) - (padding.right / (float)cols);
        //float cellHight =(parentHight / (float)rows) - ((spacing.y / (float)rows) * 2) - (padding.top / (float)rows) - (padding.bottom / (float)rows);

        //cellSize.x = cellWidth;
        //cellSize.y = cellHight;

        //int colCount = 0;
        //int rowCount = 0;

        //for(int i = 0; i < rectChildren.Count; i++)
        //{
        //    rowCount = i / cols;
        //    colCount = i % cols;

        //    var item = rectChildren[i];

        //    var xPos = (cellSize.x * colCount) + (spacing.x * colCount) + padding.left;
        //    var yPos = (cellSize.y * rowCount) + (spacing.y * rowCount) + padding.top;

        //    SetChildAlongAxis(item, 0, xPos, cellSize.x);
        //    SetChildAlongAxis(item, 1, yPos, cellSize.y);
        //}


    }

    public override void CalculateLayoutInputVertical()
    {
        throw new System.NotImplementedException();
    }

    public override void SetLayoutHorizontal()
    {
        throw new System.NotImplementedException();
    }

    public override void SetLayoutVertical()
    {
        throw new System.NotImplementedException();
    }
}
