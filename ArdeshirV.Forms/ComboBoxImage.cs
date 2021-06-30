#region Header

// Copyright© 2002-2021 ArdeshirV@protonmail.com, Licensed under LGPLv3+
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using AVFR = ArdeshirV.Forms.Properties;

#endregion
//---------------------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
	public class ComboBoxImage : ComboBox
	{
		private ImageList _images;
		
		public ComboBoxImage() : base()
	    {
	        DrawMode = DrawMode.OwnerDrawFixed;
	        DropDownStyle = ComboBoxStyle.DropDownList;
	    }
		//-------------------------------------------------------------------------------
	    protected override void OnDrawItem(DrawItemEventArgs e)
	    {
	        e.DrawBackground();
	        e.DrawFocusRectangle();
	        	
	        if(e.Index >= 0) {
	        	string strItem;
	        	try {
		        	strItem = (string)Items[e.Index];
	        	} catch(Exception) {
	        		base.OnDrawItem(e);
	        		return;
	        	}
		        
	        	SolidBrush brush = new SolidBrush(e.BackColor);
        		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		        //e.Graphics.FillRectangle(brush, e.Bounds);
		        e.Graphics.DrawString(strItem, e.Font, new SolidBrush(e.ForeColor),
		                              e.Bounds.Left + e.Bounds.Height, e.Bounds.Top + 2);
		        
		        Image pic;
		        try {
				    pic = _images.Images[strItem];
				    
			        if(pic != null)
			        	e.Graphics.DrawImage(pic, e.Bounds.Left, e.Bounds.Top,
			        	                     e.Bounds.Height, e.Bounds.Height);
	        	} catch(Exception) {
	        		base.OnDrawItem(e);
	        	}
		        finally {
		        	brush.Dispose();
		        }
	        }
	    }
		//-------------------------------------------------------------------------------
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
