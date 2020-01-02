#region Header

// Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under GPLv3+
using System;
using System.IO;
using System.Drawing;
using ArdeshirV.Forms;
using ArdeshirV.Utilities;
using System.Windows.Forms;
using AVFR = ArdeshirV.Forms.Properties;

#endregion
//---------------------------------------------------------------------------------------------
namespace ArdeshirV.Controls
{
	class ComboBoxImage : ComboBox
	{
		private ImageList _images;
		
	    public ComboBoxImage()
	    {
	        DrawMode = DrawMode.OwnerDrawFixed;
	        DropDownStyle = ComboBoxStyle.DropDownList;
	    }

	    protected override void OnDrawItem(DrawItemEventArgs e)
	    {
	        e.DrawBackground();
	        e.DrawFocusRectangle();
	        if(e.Index >= 0) {
		        string strItem = (string)Items[e.Index];
		        Image pic = _images.Images[strItem];
		        e.Graphics.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);
		        e.Graphics.DrawImage(pic, e.Bounds.Left, e.Bounds.Top, e.Bounds.Height, e.Bounds.Height);
		        e.Graphics.DrawString(strItem, e.Font, new SolidBrush(e.ForeColor),
		                              e.Bounds.Left + e.Bounds.Height, e.Bounds.Top + 2);
	        }
	
	        base.OnDrawItem(e);
	    }
	    
	    public ImageList Images {
	    	get {
	    		return _images;
	    	}
	    	set {
	    		_images = value;
	    	}
	    }
	}
}
