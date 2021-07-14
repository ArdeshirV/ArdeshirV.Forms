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
		        
	        	SolidBrush brushBack = new SolidBrush(e.BackColor);
	        	SolidBrush brushFore = new SolidBrush(e.ForeColor);
        		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		        //e.Graphics.FillRectangle(brushBack, e.Bounds);
		        e.Graphics.DrawString(strItem, e.Font, brushFore,
		                              e.Bounds.Left + e.Bounds.Height, e.Bounds.Top + 2);
		        
		        try {
				    Image pic = _images.Images[strItem];
				    
				    if(pic != null) {
				    	Rectangle rect =
				    		new Rectangle(e.Bounds.Left, e.Bounds.Top,
				    		              e.Bounds.Height, e.Bounds.Height);
				    	// e.Graphics.FillRectangle(brushBack, rect);
			        	e.Graphics.DrawImage(pic, rect);
				    }
	        	} catch(Exception) {
	        		base.OnDrawItem(e);
	        	}
		        finally {
		        	brushBack.Dispose();
		        	brushFore.Dispose();
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
