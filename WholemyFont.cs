namespace Wholemy {
	//2021.1103.2015.277
	public partial class Font277 : PathFont {
		private const double UWH = 1.0;
		private const double UXY = 100;
		private const double UD = 2;
		#region #property# Instance 
		public static Font277 instance;
		public static Font277 Instance {
			get {
				if (instance == null) instance = new Font277(); return instance;
			}
		}
		#endregion
		#region #new# 
		public Font277() { }
		#endregion
		#region #class# spaceChr 
		protected class spaceChr : Chr {
			public spaceChr() : base(' ') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				return Source ?? new PathSource();
			}
		}
		#endregion
		#region #class# tabChr 
		protected class tabChr : Chr {
			public tabChr() : base('\t') { Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				return Source ?? new PathSource();
			}
		}
		#endregion
		#region #class# 0123456789 
		#region #class# 0 
		protected class _0Chr : Chr {
			public _0Chr() : base('0') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMoved(X: 50, Y: 100);
					S.AddLin00(50, 200, 50, 600);

					S.AddArc00(50, 200, 200, 50);

					S.AddArc00(200, 50, 350, 200);

					S.AddLin00(350, 200, 350, 600);

					S.AddArc00(350, 600, 200, 750);

					S.AddArc00(200, 750, 50, 600);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# 1 
		protected class _1Chr : Chr {
			public _1Chr() : base('1') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMoved(X: 50, Y: 100);
					S.AddLin00(200, 50, 200, 750);

					S.AddLin11(200, 50, 75, 175);

					S.AddLin11(50, 750, 350, 750);
					S.CutResize();
				}
				return S;
			}
		}
		#endregion
		#region #class# 2 
		protected class _2Chr : Chr {
			public _2Chr() : base('2') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMoved(X: 50, Y: 100);
					S.AddArc10(50, 200, 200, 50);

					S.AddArc00(200, 50, 350, 200);

					S.AddLin00(350, 200, 350, 300);

					S.AddArc00(350, 300, 200, 450);

					S.AddArc00(50, 600, 200, 450);

					S.AddLin00(50, 600, 50, 750);

					S.AddLin11(50, 750, 350, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# 3 
		protected class _3Chr : Chr {
			public _3Chr() : base('3') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMoved(X: 50, Y: 100);
					S.PresetRoot(0.3);
					S.AddArc10(50, 200, 200, 50/*, 0.3*/);

					S.AddArc00(200, 50, 350, 200);

					S.AddLin00(350, 200, 350, 250);

					S.AddArc01(350, 250, 200, 400);

					S.AddArc00(200, 400, 350, 550);

					S.AddLin00(350, 550, 350, 600);

					S.AddArc00(350, 600, 200, 750);

					S.PresetRoot(-0.3);
					S.AddArc01(200, 750, 50, 600/*, -0.3*/);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# 4 
		protected class _4Chr : Chr {
			public _4Chr() : base('4') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMoved(X: 50, Y: 100);
					S.AddArc01(50, 350, 350, 50);

					S.AddLin00(50, 350, 50, 425);

					S.AddArc00(125, 500, 50, 425);

					S.AddLin00(125, 500, 350, 500);

					S.AddLin11(350, 300, 350, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# 5 
		protected class _5Chr : Chr {
			public _5Chr() : base('5') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMoved(X: 50, Y: 100);
					S.AddLin01(50, 50, 350, 50);

					S.AddLin11(50, 50, 50, 300);

					S.AddLin00(50, 300, 200, 300);

					S.AddArc00(200, 300, 350, 500);

					S.AddArc01(350, 500, 100, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# 6 
		protected class _6Chr : Chr {
			public _6Chr() : base('6') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMoved(X: 50, Y: 100);
					S.AddArc01(50, 300, 300, 50);

					S.AddLin00(50, 300, 50, 600);

					S.AddArc00(50, 500, 200, 350);

					S.AddArc00(200, 350, 350, 500);

					S.AddLin00(350, 500, 350, 600);

					S.AddArc00(350, 600, 200, 750);

					S.AddArc00(200, 750, 50, 600);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# 7 
		protected class _7Chr : Chr {
			public _7Chr() : base('7') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMoved(X: 50, Y: 100);
					S.AddLin10(50, 50, 350, 50);

					S.AddLin10(350, 50, 350, 500);

					S.AddLin11(200, 400, 350, 500);

					S.AddLin01(200, 400, 200, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# 8 
		protected class _8Chr : Chr {
			public _8Chr() : base('8') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMoved(X: 50, Y: 100);
					S.AddLin00(50, 200, 50, 250);

					S.AddArc00(50, 200, 200, 50);

					S.AddArc00(200, 50, 350, 200);

					S.AddLin00(350, 200, 350, 250);

					S.AddArc00(350, 250, 200, 400);

					S.AddArc00(200, 400, 50, 250);

					S.AddLin00(50, 550, 50, 600);

					S.AddArc00(50, 550, 200, 400);

					S.AddArc00(200, 400, 350, 550);

					S.AddLin00(350, 550, 350, 600);

					S.AddArc00(350, 600, 200, 750);

					S.AddArc00(200, 750, 50, 600);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# 9 
		protected class _9Chr : Chr {
			public _9Chr() : base('9') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMoved(X: 50, Y: 100);
					S.AddLin00(50, 200, 50, 300);

					S.AddArc00(50, 200, 200, 50);

					S.AddArc00(200, 50, 350, 200);

					S.AddLin00(350, 200, 350, 500);

					S.AddArc00(350, 300, 200, 450);

					S.AddArc00(200, 450, 50, 300);

					S.AddArc01(350, 500, 100, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#endregion
		#region #class# AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz 
		#region #class# A 
		protected class AChr : Chr {
			public AChr() { Str = Name = "A"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(50, 750, 175, 500);

					S.AddLin11(400, 50, 750, 750);

					S.AddLin00(175, 500, 625, 500);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# a 
		protected class aChr : Chr {
			public aChr() : base('a') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(50, 750, 175, 500);

					S.AddLin11(400, 50, 750, 750);

					S.AddLin00(175, 500, 625, 500);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# B 
		protected class BChr : Chr {
			public BChr() { Str = Name = "B"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc00(275, 50, 525, 275);

					S.AddLin00(525, 275, 525, 300);

					S.AddArc00(50, 275, 275, 50);

					S.AddLin00(50, 275, 50, 525);

					S.AddArc00(275, 750, 50, 525);

					S.AddLin10(275, 300, 525, 300);

					S.AddArc00(525, 300, 750, 525);

					S.AddArc00(750, 525, 525, 750);

					S.AddLin00(275, 750, 525, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# b 
		protected class bChr : Chr {
			public bChr() : base('b') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				S.Thickness = D;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc00(275, 750, 50, 525);

					S.AddLin10(50, -75, 50, 525);

					S.AddLin10(275, 300, 525, 300);

					S.AddArc00(525, 300, 750, 525);

					S.AddArc00(750, 525, 525, 750);

					S.AddLin00(275, 750, 525, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# C 
		protected class CChr : Chr {
			public CChr() { Str = Name = "C"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin10(750, 750, 400, 750);

					S.AddArc00(400, 750, 50, 400);

					S.AddArc00(50, 400, 400, 50);

					S.AddLin01(400, 50, 750, 50);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# c 
		protected class cChr : Chr {
			public cChr() : base('c') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin10(750, 750, 400, 750);

					S.AddArc00(400, 750, 50, 400);

					S.AddArc00(50, 400, 400, 50);

					S.AddLin01(400, 50, 750, 50);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# D 
		protected class DChr : Chr {
			public DChr() { Str = Name = "D"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					//S.AddArc00(275, 750, 50, 525);
					//
					//S.AddLin10(750, 50, 750, 525);
					//
					//S.AddLin01(275, 300, 525, 300);
					//
					//S.AddArc00(50, 525, 275, 300);
					//
					//S.AddArc00(750, 525, 525, 750);
					//
					//S.AddLin00(275, 750, 525, 750);
					S.AddLin11(50, 50, 50, 750);

					S.AddLin00(50, 50, 400, 50);

					S.AddArc00(400, 50, 750, 400);

					S.AddArc00(750, 400, 400, 750);

					S.AddLin00(50, 750, 400, 750);

					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# d 
		protected class dChr : Chr {
			public dChr() : base('d') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc00(275, 750, 50, 525);

					S.AddLin10(750, -75, 750, 525);

					S.AddLin01(275, 300, 525, 300);

					S.AddArc00(50, 525, 275, 300);

					S.AddArc00(750, 525, 525, 750);

					S.AddLin00(275, 750, 525, 750);
					//S.LinE(50, 50, 50, 750);
					//S.Union();
					//S.LinE(50, 50, 400, 50);
					//S.Union();
					//S.ArcE(400, 50, 750, 400);
					//S.Union();
					//S.ArcE(750, 400, 400, 750);
					//S.Union();
					//S.LinE(50, 750, 400, 750);

					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# E 
		protected class EChr : Chr {
			public EChr() { Str = Name = "E"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);

					S.AddArc00(50, 225, 225, 50);

					S.AddArc00(225, 750, 50, 575);


					S.AddLin00(50, 225, 50, 575);


					S.AddLin01(225, 50, 750, 50);

					S.AddLin01(50, 400, 400, 400);

					S.AddLin01(225, 750, 750, 750);

					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# e 
		protected class eChr : Chr {
			public eChr() : base('e') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);

					S.AddArc00(50, 225, 225, 50);

					S.AddArc00(225, 750, 50, 575);


					S.AddLin00(50, 225, 50, 575);


					S.AddLin01(225, 50, 750, 50);

					S.AddLin01(50, 400, 400, 400);

					S.AddLin01(225, 750, 750, 750);

					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# F 
		protected class FChr : Chr {
			public FChr() { Str = Name = "F"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin10(50, 750, 50, 225);

					S.AddLin01(50, 500, 400, 500);

					S.AddLin01(225, 50, 750, 50);

					S.AddArc00(50, 225, 225, 50);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# f 
		protected class fChr : Chr {
			public fChr() : base('f') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin10(50, 875, 50, 225);

					S.AddLin01(50, 500, 400, 500);

					S.AddLin01(225, 50, 750, 50);

					S.AddArc00(50, 225, 225, 50);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# G 
		protected class GChr : Chr {
			public GChr() { Str = Name = "G"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin10(750, 750, 750, 400);

					S.AddLin11(400, 400, 750, 400);

					S.AddLin00(750, 750, 400, 750);

					S.AddArc00(400, 750, 50, 400);

					S.AddArc00(50, 400, 400, 50);

					S.AddLin01(400, 50, 750, 50);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# g 
		protected class gChr : Chr {
			public gChr() : base('g') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					//S.AddLin10(750, 750, 750, 400);
					//
					//S.AddLin11(400, 400, 750, 400);
					//
					//S.AddLin00(750, 750, 400, 750);
					//
					//S.AddArc00(400, 750, 50, 400);
					//
					//S.AddArc00(50, 400, 400, 50);
					//
					//S.AddLin01(400, 50, 750, 50);
					S.AddArc00(50, 275, 275, 50);

					S.AddLin00(275, 50, 525, 50);

					S.AddArc00(525, 50, 750, 275);

					S.AddArc00(275, 500, 50, 275);

					S.AddLin01(275, 500, 400, 500);

					S.AddLin00(750, 275, 750, 575);

					S.AddArc01(750, 575, 400, 875);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# H 
		protected class HChr : Chr {
			public HChr() { Str = Name = "H"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(50, 50, 50, 750);

					S.AddArc01(400, 400, 750, 750);

					S.AddLin00(50, 400, 400, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# h 
		protected class hChr : Chr {
			public hChr() : base('h') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(50, -75, 50, 750);

					S.AddArc01(400, 400, 750, 750);

					S.AddLin00(50, 400, 400, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# I 
		protected class IChr : Chr {
			public IChr() { Str = Name = "I"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(50, 50, 750, 50);

					S.AddLin00(400, 50, 400, 750);

					S.AddLin11(50, 750, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# i 
		protected class iChr : Chr {
			public iChr() : base('i') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(50, 50, 750, 50);

					S.AddLin10(400, -75, 400, 750);

					S.AddLin11(50, 750, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# J 
		protected class JChr : Chr {
			public JChr() { Str = Name = "J"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin00(225, 750, 575, 750);

					S.AddLin10(750, 50, 750, 575);

					S.AddArc00(750, 575, 575, 750);

					S.AddArc01(225, 750, 50, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# j 
		protected class jChr : Chr {
			public jChr() : base('j') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin00(225, 750, 575, 750);

					S.AddLin10(750, -75, 750, 575);

					S.AddArc00(750, 575, 575, 750);

					S.AddArc01(225, 750, 50, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# K 
		protected class KChr : Chr {
			public KChr() { Str = Name = "K"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(50, 50, 50, 750);

					S.AddLin00(50, 400, 400, 400);

					S.AddLin01(400, 400, 750, 50);

					S.AddLin10(750, 750, 400, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# k 
		protected class kChr : Chr {
			public kChr() : base('k') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(50, -75, 50, 750);

					S.AddLin00(50, 400, 400, 400);

					S.AddLin01(400, 400, 750, 50);

					S.AddLin10(750, 750, 400, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# L 
		protected class LChr : Chr {
			public LChr() { Str = Name = "L"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin10(50, 50, 50, 575);

					S.AddArc00(225, 750, 50, 575);

					S.AddLin01(225, 750, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# l 
		protected class lChr : Chr {
			public lChr() : base('l') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin10(50, -75, 50, 575);

					S.AddArc00(225, 750, 50, 575);

					S.AddLin01(225, 750, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# M 
		protected class MChr : Chr {
			public MChr() { Str = Name = "M"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(50, 50, 50, 750);

					S.AddLin01(50, 50, 400, 400);

					S.AddLin00(400, 400, 750, 50);

					S.AddLin11(750, 50, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# m 
		protected class mChr : Chr {
			public mChr() : base('m') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(50, 50, 50, 750);

					S.AddLin01(50, 50, 400, 400);

					S.AddLin00(400, 400, 750, 50);

					S.AddLin11(750, 50, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# N 
		protected class NChr : Chr {
			public NChr() { Str = Name = "N"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(50, 50, 50, 750);

					S.AddLin00(50, 50, 750, 750);

					S.AddLin11(750, 50, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# n 
		protected class nChr : Chr {
			public nChr() : base('n') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(50, 50, 50, 750);

					S.AddLin00(50, 50, 750, 750);

					S.AddLin11(750, 50, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# O 
		protected class OChr : Chr {
			public OChr() { Str = Name = "O"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;
					S.AddResizeMovA(XY: UXY, WH: UWH);

					S.AddArc00(400, 50, 750, 400);

					S.AddArc00(750, 400, 400, 750);

					S.AddArc00(400, 750, 50, 400);

					S.AddArc00(50, 400, 400, 50);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# o 
		protected class oChr : Chr {
			public oChr() : base('o') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					S.Thickness = D;
					S.AddResizeMovA(WH: 0.5, X: 50, Y: 300);

					S.AddArc00(400, 50, 750, 400);

					S.AddArc00(750, 400, 400, 750);

					S.AddArc00(400, 750, 50, 400);

					S.AddArc00(50, 400, 400, 50);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# P 
		protected class PChr : Chr {
			public PChr() { Str = Name = "P"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin01(50, 275, 50, 750);

					S.AddArc00(50, 275, 275, 50);

					S.AddLin00(275, 50, 525, 50);

					S.AddArc00(525, 50, 750, 275);

					S.AddArc00(750, 275, 525, 500);

					S.AddLin10(275, 500, 525, 500);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# p 
		protected class pChr : Chr {
			public pChr() : base('p') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin01(50, 275, 50, 875);

					S.AddArc00(50, 275, 275, 50);

					S.AddLin00(275, 50, 525, 50);

					S.AddArc00(525, 50, 750, 275);

					S.AddArc00(750, 275, 525, 500);

					S.AddLin10(275, 500, 525, 500);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Q 
		protected class QChr : Chr {
			public QChr() { Str = Name = "Q"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					//S.AddLin01(750, 275, 750, 750);
					//
					//S.AddArc00(50, 275, 275, 50);
					//
					//S.AddLin00(275, 50, 525, 50);
					//
					//S.AddArc00(525, 50, 750, 275);
					//
					//S.AddArc00(275, 500, 50, 275);
					//
					//S.AddLin01(275, 500, 525, 500);
					S.AddArc00(400, 750, 50, 400);

					S.AddArc00(50, 400, 400, 50);

					S.AddArc00(400, 50, 750, 400);

					S.AddArc00(750, 400, 400, 750);

					S.AddLin11(525, 525, 750, 750);

					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# q 
		protected class qChr : Chr {
			public qChr() : base('q') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin01(750, 275, 750, 875);

					S.AddArc00(50, 275, 275, 50);

					S.AddLin00(275, 50, 525, 50);

					S.AddArc00(525, 50, 750, 275);

					S.AddArc00(275, 500, 50, 275);

					S.AddLin01(275, 500, 525, 500);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# R 
		protected class RChr : Chr {
			public RChr() { Str = Name = "R"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin01(50, 275, 50, 750);

					S.AddArc00(50, 275, 275, 50);

					S.AddLin00(275, 50, 525, 50);

					S.AddArc00(525, 50, 750, 275);

					S.AddArc00(750, 275, 525, 500);

					S.AddLin10(275, 500, 525, 500);

					S.AddLin01(275, 500, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# r 
		protected class rChr : Chr {
			public rChr() : base('r') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin01(50, 275, 50, 875);

					S.AddArc00(50, 275, 275, 50);

					S.AddLin00(275, 50, 525, 50);

					S.AddArc00(525, 50, 750, 275);

					S.AddArc00(750, 275, 525, 500);

					S.AddLin10(275, 500, 525, 500);

					S.AddLin01(275, 500, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# S 
		protected class SChr : Chr {
			public SChr() { Str = Name = "S"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.PresetRoot(-0.3);
					S.AddArc01(575, 50, 750, 225/*, -0.3*/);

					S.AddLin00(225, 50, 575, 50);

					S.AddArc00(50, 225, 225, 50);

					S.AddArc00(225, 400, 50, 225);

					S.AddLin00(225, 400, 575, 400);

					S.AddArc00(575, 400, 750, 575);

					S.AddArc00(750, 575, 575, 750);

					S.AddLin00(225, 750, 575, 750);

					S.PresetRoot(-0.3);
					S.AddArc01(225, 750, 50, 575/*, -0.3*/);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# s 
		protected class sChr : Chr {
			public sChr() : base('s') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.PresetRoot(-0.3);
					S.AddArc01(575, 50, 750, 225/*, -0.3*/);

					S.AddLin00(225, 50, 575, 50);

					S.AddArc00(50, 225, 225, 50);

					S.AddArc00(225, 400, 50, 225);

					S.AddLin00(225, 400, 575, 400);

					S.AddArc00(575, 400, 750, 575);

					S.AddArc00(750, 575, 575, 750);

					S.AddLin00(225, 750, 575, 750);

					S.PresetRoot(-0.3);
					S.AddArc01(225, 750, 50, 575/*, -0.3*/);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# T 
		protected class TChr : Chr {
			public TChr() { Str = Name = "T"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//if (D > 0) {
				//	D /= UD;
				//	S.Begin();
				//	S.ResizePush(1, 100, 100);
				//	S.LinE(50, 50, 750, 50);
				//	S.Union();
				//	S.LinE(400, 50, 400, 750);
				//	
				//	S.ResizePop();
				//	return S.ComPath();
				//}
				if (D > 0) {
					D /= UD;
					S.Thickness = D;
					S.AddResizeMovA(XY: UXY, WH: UWH);

					S.AddLin11(50, 50, 750, 50);

					S.AddLin01(400, 50, 400, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# t 
		protected class tChr : Chr {
			public tChr() : base('t') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				////D *= 2;
				//if (D > 0) {
				//	S.Begin();
				//	S.ResizePush(0.5, 50, 300);
				//	S.LinE(50, 50, 750, 50);
				//	S.Union();
				//	S.LinE(400, 50, 400, 750);
				//	
				//	S.ResizePop();
				//	return S.ComPath();
				//}
				if (D > 0) {
					S.Thickness = D;
					S.AddResizeMovA(WH: 0.5, X: 50, Y: 300);

					S.AddLin11(50, 50, 750, 50);

					S.AddLin11(400, -75, 400, 875);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# U 
		protected class UChr : Chr {
			public UChr() { Str = Name = "U"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin10(750, 50, 750, 400);

					S.AddArc00(750, 400, 400, 750);

					S.AddArc00(400, 750, 50, 400);

					S.AddLin10(50, 50, 50, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# u 
		protected class uChr : Chr {
			public uChr() : base('u') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin10(750, 50, 750, 400);

					S.AddArc00(750, 400, 400, 750);

					S.AddArc00(400, 750, 50, 400);

					S.AddLin10(50, 50, 50, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# V 
		protected class VChr : Chr {
			public VChr() { Str = Name = "V"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(50, 50, 400, 750);

					S.AddLin10(750, 50, 400, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# v 
		protected class vChr : Chr {
			public vChr() : base('v') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(50, 50, 400, 750);

					S.AddLin10(750, 50, 400, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# W 
		protected class WChr : Chr {
			public WChr() { Str = Name = "W"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin10(50, 50, 50, 575);

					S.AddArc00(225, 750, 50, 575);

					S.AddArc00(400, 575, 225, 750);

					S.AddLin10(400, 225, 400, 575);

					S.AddArc00(575, 750, 400, 575);

					S.AddArc00(750, 575, 575, 750);

					S.AddLin10(750, 50, 750, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# w 
		protected class wChr : Chr {
			public wChr() : base('w') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin10(50, 50, 50, 575);

					S.AddArc00(225, 750, 50, 575);

					S.AddArc00(400, 575, 225, 750);

					S.AddLin10(400, 225, 400, 575);

					S.AddArc00(575, 750, 400, 575);

					S.AddArc00(750, 575, 575, 750);

					S.AddLin10(750, 50, 750, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# X 
		protected class XChr : Chr {
			public XChr() { Str = Name = "X"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(50, 50, 750, 750);

					S.AddLin11(750, 50, 50, 750);

					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# x 
		protected class xChr : Chr {
			public xChr() : base('x') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(50, 50, 750, 750);

					S.AddLin11(750, 50, 50, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Y 
		protected class YChr : Chr {
			public YChr() { Str = Name = "Y"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc10(750, 50, 400, 400);

					S.AddArc01(400, 400, 50, 50);

					S.AddLin01(400, 400, 400, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# y 
		protected class yChr : Chr {
			public yChr() : base('y') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc10(750, 50, 400, 400);

					S.AddArc01(400, 400, 50, 50);

					S.AddLin01(400, 400, 400, 875);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Z 
		protected class ZChr : Chr {
			public ZChr() { Str = Name = "Z"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(50, 50, 750, 50);

					S.AddLin00(50, 750, 750, 50);

					S.AddLin11(50, 750, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# z 
		protected class zChr : Chr {
			public zChr() : base('z') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(50, 50, 750, 50);

					S.AddLin00(50, 750, 750, 50);

					S.AddLin11(50, 750, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#endregion
		#region #class# АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя 
		#region #class# А 
		protected class АChr : Chr {
			public АChr() { Str = "А"; Name = "ruA"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc10(50, 750, 575, 50);

					S.AddArc00(575, 50, 750, 225);

					S.AddLin01(750, 225, 750, 750);

					S.AddLin10(225, 575, 750, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# а 
		protected class аChr : Chr {
			public аChr() : base('а') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc10(50, 750, 575, 50);

					S.AddArc00(575, 50, 750, 225);

					S.AddLin01(750, 225, 750, 750);

					S.AddLin10(225, 575, 750, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Б 
		protected class БChr : Chr {
			public БChr() { Str = "Б"; Name = "ruB"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc10(225, 400, 750, 575);

					S.AddArc00(750, 575, 225, 750);

					S.AddArc01(50, 575, 575, 50);

					S.AddArc00(225, 750, 50, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# б 
		protected class бChr : Chr {
			public бChr() : base('б') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc10(225, 400, 750, 575);

					S.AddArc00(750, 575, 225, 750);

					S.AddArc01(50, 575, 575, 50);

					S.AddArc00(225, 750, 50, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# В 
		protected class ВChr : Chr {
			public ВChr() { Str = "В"; Name = "ruV"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc00(225, 50, 575, 225);

					S.AddArc00(575, 225, 225, 400);

					S.AddArc10(225, 400, 750, 575);

					S.AddArc00(750, 575, 225, 750);

					S.AddArc00(50, 225, 225, 50);

					S.AddLin00(50, 225, 50, 575);

					S.AddArc00(225, 750, 50, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# в 
		protected class вChr : Chr {
			public вChr() : base('в') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc00(225, 50, 575, 225);

					S.AddArc00(575, 225, 225, 400);

					S.AddArc10(225, 400, 750, 575);

					S.AddArc00(750, 575, 225, 750);

					S.AddArc00(50, 225, 225, 50);

					S.AddLin00(50, 225, 50, 575);

					S.AddArc00(225, 750, 50, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Г 
		protected class ГChr : Chr {
			public ГChr() { Str = "Г"; Name = "ruG"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc00(50, 225, 400, 50);

					S.AddArc01(400, 50, 750, 225);

					S.AddLin01(50, 225, 50, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# г 
		protected class гChr : Chr {
			public гChr() : base('г') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc00(50, 225, 400, 50);

					S.AddArc01(400, 50, 750, 225);

					S.AddLin01(50, 225, 50, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Д 
		protected class ДChr : Chr {
			public ДChr() { Str = "Д"; Name = "ruD"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc00(50, 225, 400, 50);

					S.AddArc00(400, 50, 750, 225);

					S.AddArc00(400, 575, 50, 225);

					S.AddArc00(750, 225, 400, 575);

					S.AddArc01(400, 575, 50, 750);

					S.AddArc10(750, 750, 400, 575);
					//
					//S.AddLin10(50, 750, 225, 750);
					//
					//S.AddLin01(575, 750, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# д 
		protected class дChr : Chr {
			public дChr() : base('д') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc00(50, 225, 400, 50);

					S.AddArc00(400, 50, 750, 225);

					S.AddArc00(400, 575, 50, 225);

					S.AddArc00(750, 225, 400, 575);

					S.AddArc01(400, 575, 50, 750);

					S.AddArc10(750, 750, 400, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Е 
		protected class ЕChr : Chr {
			public ЕChr() { Str = "Е"; Name = "ruE"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc00(50, 225, 400, 50);

					S.AddArc00(400, 50, 750, 225);

					S.AddArc01(750, 225, 225, 400);

					S.AddArc10(575, 750, 50, 225);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# е 
		protected class еChr : Chr {
			public еChr() : base('е') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc00(50, 225, 400, 50);

					S.AddArc00(400, 50, 750, 225);

					S.AddArc01(750, 225, 225, 400);

					S.AddArc10(575, 750, 50, 225);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Ё 
		protected class ЁChr : Chr {
			public ЁChr() { Str = "Ё"; Name = "ruEE"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.PresetRoot(0.5);
					S.AddArc10(150, -50, 250, -150/*, 0.5*/);

					S.PresetRoot(-0.5);
					S.AddArc01(250, -150, 350, -50/*, -0.5*/);

					S.PresetRoot(0.5);
					S.AddArc10(450, -50, 550, -150/*, 0.5*/);

					S.PresetRoot(-0.5);
					S.AddArc01(550, -150, 650, -50/*, -0.5*/);

					S.AddArc00(50, 225, 400, 50);

					S.AddArc00(400, 50, 750, 225);

					S.AddArc01(750, 225, 225, 400);

					S.AddArc10(575, 750, 50, 225);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# ё 
		protected class ёChr : Chr {
			public ёChr() : base('ё') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.PresetRoot(0.5);
					S.AddArc10(150, -175, 250, -275/*, 0.5*/);

					S.PresetRoot(-0.5);
					S.AddArc01(250, -275, 350, -175/*, -0.5*/);

					S.PresetRoot(0.5);
					S.AddArc10(450, -175, 550, -275/*, 0.5*/);

					S.PresetRoot(-0.5);
					S.AddArc01(550, -275, 650, -175/*, -0.5*/);

					S.AddArc00(50, 225, 400, 50);

					S.AddArc00(400, 50, 750, 225);

					S.AddArc01(750, 225, 225, 400);

					S.AddArc10(575, 750, 50, 225);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# ë 
		//protected class ëChr : Chr {
		//	public ëChr() : base('ë') { Width = 500; Height = 1000;}
		//	public override PathSource Get(double D = 0, PathSource Source = null) {
		//		var S = Source ?? new PathSource(500, 1000);
		//		//D *= 2;
		//		if (D > 0) {
		//			S.Thickness = D;
		//			
		//			S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
		//			//S.AddArc10(150, -50, 250, -150, D, 0.5);
		//			//
		//			//S.AddArc01(250, -150, 350, -50, D, -0.5);
		//			//
		//			//S.AddArc10(450, -50, 550, -150, D, 0.5);
		//			//
		//			//S.AddArc01(550, -150, 650, -50, D, -0.5);
		//			S.AddLin11(250, -150, 250, -100);
		//			
		//			S.AddLin11(550, -150, 550, -100);
		//			
		//			S.AddArc00(50, 225, 400, 50);
		//			
		//			S.AddArc00(400, 50, 750, 225);
		//			
		//			S.AddArc01(750, 225, 225, 400);
		//			
		//			S.AddArc10(575, 750, 50, 225);
		//			S.CutResize();
		//			
		//		}
		//		return S;
		//	}
		//}
		#endregion
		#region #class# Ж 
		protected class ЖChr : Chr {
			public ЖChr() { Str = "Ж"; Name = "ruGE"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc10(750, 50, 400, 400);

					S.AddArc01(400, 400, 50, 50);

					S.AddLin11(400, 50, 400, 750);

					S.AddArc10(50, 750, 400, 400);

					S.AddArc01(400, 400, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# ж 
		protected class жChr : Chr {
			public жChr() : base('ж') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc10(750, 50, 400, 400);

					S.AddArc01(400, 400, 50, 50);

					S.AddLin11(400, 50, 400, 750);

					S.AddArc10(50, 750, 400, 400);

					S.AddArc01(400, 400, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# З 
		protected class ЗChr : Chr {
			public ЗChr() { Str = "З"; Name = "ruZ"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc10(50, 225, 400, 50);

					S.AddArc00(400, 50, 750, 225);

					S.AddArc01(750, 225, 400, 400);

					S.AddArc00(400, 400, 750, 575);

					S.AddArc00(750, 575, 400, 750);

					S.AddArc01(400, 750, 50, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# з 
		protected class зChr : Chr {
			public зChr() : base('з') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc10(50, 225, 400, 50);

					S.AddArc00(400, 50, 750, 225);

					S.AddArc01(750, 225, 400, 400);

					S.AddArc00(400, 400, 750, 575);

					S.AddArc00(750, 575, 400, 750);

					S.AddArc01(400, 750, 50, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# И 
		protected class ИChr : Chr {
			public ИChr() { Str = "И"; Name = "ruI"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(750, 50, 750, 750);

					S.AddArc00(750, 225, 225, 750);

					S.AddArc00(225, 750, 50, 575);

					S.AddLin10(50, 50, 50, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# и 
		protected class иChr : Chr {
			public иChr() : base('и') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(750, 50, 750, 750);

					S.AddArc00(750, 225, 225, 750);

					S.AddArc00(225, 750, 50, 575);

					S.AddLin10(50, 50, 50, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Й 
		protected class ЙChr : Chr {
			public ЙChr() { Str = "Й"; Name = "ruII"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc10(550, -150, 400, 0);

					S.AddArc01(400, 0, 250, -150);

					S.AddLin11(750, 50, 750, 750);

					S.AddArc00(750, 225, 225, 750);

					S.AddArc00(225, 750, 50, 575);

					S.AddLin10(50, 50, 50, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# й 
		protected class йChr : Chr {
			public йChr() : base('й') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc10(550, -275, 400, -125);

					S.AddArc01(400, -125, 250, -275);

					S.AddLin11(750, 50, 750, 750);

					S.AddArc00(750, 225, 225, 750);

					S.AddArc00(225, 750, 50, 575);

					S.AddLin10(50, 50, 50, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# К 
		protected class КChr : Chr {
			public КChr() { Str = "К"; Name = "ruK"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(50, 50, 50, 750);

					S.AddArc10(750, 50, 50, 400);

					S.AddArc01(50, 400, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# к 
		protected class кChr : Chr {
			public кChr() : base('к') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(50, 50, 50, 750);

					S.AddArc10(750, 50, 50, 400);

					S.AddArc01(50, 400, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Л 
		protected class ЛChr : Chr {
			public ЛChr() { Str = "Л"; Name = "ruL"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc11(400, 50, 50, 750);

					S.AddArc10(750, 750, 400, 50);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# л 
		protected class лChr : Chr {
			public лChr() : base('л') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc11(400, 50, 50, 750);

					S.AddArc10(750, 750, 400, 50);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# М 
		protected class МChr : Chr {
			public МChr() { Str = "М"; Name = "ruM"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(50, 50, 50, 750);

					S.AddArc01(50, 50, 400, 575);

					S.AddArc00(400, 575, 750, 50);

					S.AddLin11(750, 50, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# м 
		protected class мChr : Chr {
			public мChr() : base('м') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(50, 50, 50, 750);

					S.AddArc01(50, 50, 400, 575);

					S.AddArc00(400, 575, 750, 50);

					S.AddLin11(750, 50, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Н 
		protected class НChr : Chr {
			public НChr() { Str = "Н"; Name = "ruN"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(50, 50, 50, 750);

					S.AddLin00(50, 400, 750, 400);

					S.AddLin11(750, 50, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# н 
		protected class нChr : Chr {
			public нChr() : base('н') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(50, 50, 50, 750);

					S.AddLin00(50, 400, 750, 400);

					S.AddLin11(750, 50, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# О 
		protected class ОChr : Chr {
			public ОChr() { Str = "О"; Name = "ruO"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc00(50, 225, 400, 50);

					S.AddArc00(400, 50, 750, 225);

					S.AddArc00(750, 400, 400, 750);

					S.AddArc00(400, 750, 50, 400);

					S.AddLin00(50, 225, 50, 400);

					S.AddLin00(750, 225, 750, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# о 
		protected class оChr : Chr {
			public оChr() : base('о') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc00(50, 225, 400, 50);

					S.AddArc00(400, 50, 750, 225);

					S.AddArc00(750, 400, 400, 750);

					S.AddArc00(400, 750, 50, 400);

					S.AddLin00(50, 225, 50, 400);

					S.AddLin00(750, 225, 750, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# П 
		protected class ПChr : Chr {
			public ПChr() { Str = "П"; Name = "ruP"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin01(50, 225, 50, 750);

					S.AddArc00(50, 225, 400, 50);

					S.AddArc00(400, 50, 750, 225);

					S.AddLin01(750, 225, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# п 
		protected class пChr : Chr {
			public пChr() : base('п') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin01(50, 225, 50, 750);

					S.AddArc00(50, 225, 400, 50);

					S.AddArc00(400, 50, 750, 225);

					S.AddLin01(750, 225, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Р 
		protected class РChr : Chr {
			public РChr() { Str = "Р"; Name = "ruR"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin01(50, 225, 50, 750);

					S.AddArc00(50, 225, 225, 50);

					S.AddArc00(225, 50, 750, 225);

					S.AddArc01(750, 225, 225, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# р 
		protected class рChr : Chr {
			public рChr() : base('р') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin01(50, 225, 50, 750);

					S.AddArc00(50, 225, 225, 50);

					S.AddArc00(225, 50, 750, 225);

					S.AddArc01(750, 225, 225, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# С 
		protected class СChr : Chr {
			public СChr() { Str = "С"; Name = "ruS"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc01(575, 50, 750, 225);

					S.AddArc00(50, 575, 575, 50);

					S.AddArc00(400, 750, 50, 575);

					S.AddArc10(750, 575, 400, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# с 
		protected class сChr : Chr {
			public сChr() : base('с') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc01(575, 50, 750, 225);

					S.AddArc00(50, 575, 575, 50);

					S.AddArc00(400, 750, 50, 575);

					S.AddArc10(750, 575, 400, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Т 
		protected class ТChr : Chr {
			public ТChr() { Str = "Т"; Name = "ruT"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc10(50, 50, 400, 225);

					S.AddArc01(400, 225, 750, 50);

					S.AddLin10(400, 750, 400, 225);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# т 
		protected class тChr : Chr {
			public тChr() : base('т') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc10(50, 50, 400, 225);

					S.AddArc01(400, 225, 750, 50);

					S.AddLin10(400, 750, 400, 225);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# У 
		protected class УChr : Chr {
			public УChr() { Str = "У"; Name = "ruU"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc11(575, 400, 50, 50);

					S.AddArc11(750, 50, 225, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# у 
		protected class уChr : Chr {
			public уChr() : base('у') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc11(575, 400, 50, 50);

					S.AddArc11(750, 50, 225, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Ф 
		protected class ФChr : Chr {
			public ФChr() { Str = "Ф"; Name = "ruF"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(400, 50, 400, 750);

					S.AddArc00(50, 400, 400, 225);

					S.AddArc00(400, 225, 750, 400);

					S.AddArc00(750, 400, 400, 575);

					S.AddArc00(400, 575, 50, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# ф 
		protected class фChr : Chr {
			public фChr() : base('ф') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(400, -75, 400, 875);

					S.AddArc00(50, 400, 400, 225);

					S.AddArc00(400, 225, 750, 400);

					S.AddArc00(750, 400, 400, 575);

					S.AddArc00(400, 575, 50, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Х 
		protected class ХChr : Chr {
			public ХChr() { Str = "Х"; Name = "ruX"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc10(50, 50, 400, 400);

					S.AddArc01(400, 400, 750, 50);

					S.AddArc01(400, 400, 50, 750);

					S.AddArc10(750, 750, 400, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# х 
		protected class хChr : Chr {
			public хChr() : base('х') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc10(50, 50, 400, 400);

					S.AddArc01(400, 400, 750, 50);

					S.AddArc01(400, 400, 50, 750);

					S.AddArc10(750, 750, 400, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Ц 
		protected class ЦChr : Chr {
			public ЦChr() { Str = "Ц"; Name = "ruCC"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin10(50, 50, 50, 575);

					S.AddArc00(575, 575, 312.5, 750);

					S.AddArc00(312.5, 750, 50, 575);

					S.AddLin10(575, 50, 575, 575);

					S.AddLin01(575, 575, 750, 575);

					S.AddLin01(750, 575, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# ц 
		protected class цChr : Chr {
			public цChr() : base('ц') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin10(50, -75, 50, 575);

					S.AddArc00(575, 575, 312.5, 750);

					S.AddArc00(312.5, 750, 50, 575);

					S.AddLin10(575, -75, 575, 575);

					S.AddLin01(575, 575, 750, 575);

					S.AddLin01(750, 575, 750, 875);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Ч 
		protected class ЧChr : Chr {
			public ЧChr() { Str = "Ч"; Name = "ruCH"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					//S.AddLin00(400, 400, 750, 400);
					//
					S.AddArc01(750, 400, 50, 50);

					S.AddLin11(750, 50, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# ч 
		protected class чChr : Chr {
			public чChr() : base('ч') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					//S.AddLin00(400, 400, 750, 400);
					//
					S.AddArc01(750, 400, 50, 50);

					S.AddLin11(750, 50, 750, 875);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Ш 
		protected class ШChr : Chr {
			public ШChr() { Str = "Ш"; Name = "ruSH"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(400, 50, 400, 575);

					S.AddLin10(50, 50, 50, 575);

					S.AddLin10(750, 50, 750, 575);

					S.AddArc00(400, 750, 50, 575);

					S.AddArc00(750, 575, 400, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# ш 
		protected class шChr : Chr {
			public шChr() : base('ш') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(400, 50, 400, 575);

					S.AddLin10(50, 50, 50, 575);

					S.AddLin10(750, 50, 750, 575);

					S.AddArc00(400, 750, 50, 575);

					S.AddArc00(750, 575, 400, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Щ 
		protected class ЩChr : Chr {
			public ЩChr() { Str = "Щ"; Name = "ruSHE"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(312.5, 175, 312.5, 575);

					S.AddLin10(50, 50, 50, 575);

					S.AddArc00(575, 575, 312.5, 750);

					S.AddArc00(312.5, 750, 50, 575);

					S.AddLin10(575, 50, 575, 575);

					S.AddLin01(575, 575, 750, 575);

					S.AddLin01(750, 575, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# щ 
		protected class щChr : Chr {
			public щChr() : base('щ') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin11(312.5, 50, 312.5, 575);

					S.AddLin10(50, -75, 50, 575);

					S.AddArc00(575, 575, 312.5, 750);

					S.AddArc00(312.5, 750, 50, 575);

					S.AddLin10(575, -75, 575, 575);

					S.AddLin01(575, 575, 750, 575);

					S.AddLin01(750, 575, 750, 875);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Ъ 
		protected class ЪChr : Chr {
			public ЪChr() { Str = "Ъ"; Name = "ruYT"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin10(50, 50, 225, 50);

					S.AddLin10(225, 50, 225, 750);

					S.AddArc00(225, 400, 750, 575);

					S.AddArc01(750, 575, 225, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# ъ 
		protected class ъChr : Chr {
			public ъChr() : base('ъ') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin10(50, -75, 225, -75);

					S.AddLin10(225, -75, 225, 750);

					S.AddArc00(225, 400, 750, 575);

					S.AddArc01(750, 575, 225, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Ы 
		protected class ЫChr : Chr {
			public ЫChr() { Str = "Ы"; Name = "ruYI"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(750, 50, 750, 750);

					S.AddLin10(50, 50, 50, 575);

					S.AddArc00(225, 750, 50, 575);

					S.PresetRoot(-0.465);
					S.AddArc10(225, 400, 750, 925/*, -0.465*/);

					S.AddArc00(750, 225, 225, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# ы 
		protected class ыChr : Chr {
			public ыChr() : base('ы') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMovA(WH: 0.5, X: 50, Y: 300);
					S.AddLin11(750, 50, 750, 750);

					S.AddLin10(50, 50, 50, 575);

					S.AddArc00(225, 750, 50, 575);

					S.PresetRoot(-0.465);
					S.AddArc10(225, 400, 750, 925/*, -0.465*/);

					S.AddArc00(750, 225, 225, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Ь 
		protected class ЬChr : Chr {
			public ЬChr() { Str = "Ь"; Name = "ruY"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin10(50, 50, 50, 575);

					S.AddArc00(225, 750, 50, 575);

					S.AddArc10(225, 400, 750, 575);

					S.AddArc00(750, 575, 225, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# ь 
		protected class ьChr : Chr {
			public ьChr() : base('ь') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddLin10(50, 50, 50, 575);

					S.AddArc00(225, 750, 50, 575);

					S.AddArc10(225, 400, 750, 575);

					S.AddArc00(750, 575, 225, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Э 
		protected class ЭChr : Chr {
			public ЭChr() { Str = "Э"; Name = "ruEEE"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc10(50, 225, 400, 50);

					S.AddArc00(400, 50, 750, 225);

					S.AddLin11(400, 400, 575, 400);

					S.AddArc01(750, 225, 225, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# э 
		protected class эChr : Chr {
			public эChr() : base('э') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc10(50, 225, 400, 50);

					S.AddArc00(400, 50, 750, 225);

					S.AddLin11(400, 400, 575, 400);

					S.AddArc01(750, 225, 225, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Ю 
		protected class ЮChr : Chr {
			public ЮChr() { Str = "Ю"; Name = "ruUU"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc00(225, 400, 575, 50);

					S.AddArc00(575, 50, 750, 400);

					S.AddArc00(750, 400, 575, 750);

					S.AddArc00(575, 750, 225, 400);

					S.AddArc01(225, 400, 50, 50);

					S.AddArc10(50, 750, 225, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# ю 
		protected class юChr : Chr {
			public юChr() : base('ю') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc00(225, 400, 575, 50);

					S.AddArc00(575, 50, 750, 400);

					S.AddArc00(750, 400, 575, 750);

					S.AddArc00(575, 750, 225, 400);

					S.AddArc01(225, 400, 50, 50);

					S.AddArc10(50, 750, 225, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# Я 
		protected class ЯChr : Chr {
			public ЯChr() { Str = "Я"; Name = "ruYA"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc00(575, 400, 750, 575);

					S.PresetRoot(-0.6);
					S.AddArc01(225, 750, 50, 575/*, -0.6*/);

					S.AddArc00(575, 400, 225, 750);

					S.AddLin01(750, 575, 750, 750);

					S.AddArc00(50, 225, 575, 50);

					S.AddArc00(575, 50, 750, 225);

					S.AddArc00(750, 225, 575, 400);

					S.AddArc00(575, 400, 50, 225);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# я 
		protected class яChr : Chr {
			public яChr() : base('я') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				//D *= 2;
				if (D > 0) {
					S.Thickness = D;

					S.AddResizeMoved(WH: 0.5, XY: 100, Y: 500);
					S.AddArc00(575, 400, 750, 575);

					S.PresetRoot(-0.6);
					S.AddArc01(225, 750, 50, 575/*, -0.6*/);

					S.AddArc00(575, 400, 225, 750);

					S.AddLin01(750, 575, 750, 750);

					S.AddArc00(50, 225, 575, 50);

					S.AddArc00(575, 50, 750, 225);

					S.AddArc00(750, 225, 575, 400);

					S.AddArc00(575, 400, 50, 225);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#endregion
		#region #class# €¥₽$№#%/\\,;.:-+*(){}[]|<>=?!&@'\"«»`´~~×^_± 
		#region #class# € 
		//protected class E_Chr : Chr {
		//	public E_Chr() { Str = Name = "€"; Width = 500; Height = 1000; }
		//	public override PathSource Get(double D = 0, PathSource Source = null) {
		//		var S = Source ?? new PathSource(1000, 1000);
		//		if (D > 0) {
		//			D /= UD;
		//			S.Thickness = D;
		//			
		//			S.AddResizeMovA(XY: 100);

		//			S.AddLin10(50, 225, 225, 225);
		//			
		//			S.AddLin10(50, 575, 225, 575);
		//			

		//			S.AddArc00(225, 225, 400, 50);
		//			
		//			S.AddArc00(400, 750, 225, 575);
		//			

		//			S.AddLin00(225, 225, 225, 575);
		//			

		//			S.AddLin01(400, 50, 750, 50);
		//			
		//			S.AddLin01(225, 400, 575, 400);
		//			
		//			S.AddLin01(400, 750, 750, 750);

		//			S.CutResize();
		//			
		//		}
		//		return S;
		//	}
		//}
		#endregion
		#region #class# ¥ 
		//protected class Y_Chr : Chr {
		//	public Y_Chr() { Str = Name = "¥"; Width = 1000; Height = 1000; }
		//	public override PathSource Get(double D = 0, PathSource Source = null) {
		//		var S = Source ?? new PathSource(1000, 1000);
		//		if (D > 0) {
		//			D /= UD;
		//			S.Thickness = D;
		//			
		//			S.AddResizeMovA(XY: 100);
		//			S.AddArc10(750, 50, 400, 400);
		//			
		//			S.AddArc01(400, 400, 50, 50);
		//			
		//			S.AddLin01(400, 400, 400, 750);
		//			
		//			S.AddLin11(150, 575, 650, 575);
		//			S.CutResize();
		//			
		//		}
		//		return S;
		//	}
		//}
		#endregion
		#region #class# ₽ 
		protected class rublChr : Chr {
			public rublChr() : base('₽') { Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(225, 50, 225, 750);

					S.AddArc00(225, 50, 750, 225);

					S.AddArc00(750, 225, 225, 400);

					S.AddLin11(400, 600, 50, 600);

					S.AddLin10(50, 400, 225, 400);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# $ 
		protected class dollarChr : Chr {
			public dollarChr() : base('$') { Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin10(225, 50, 225, 150);

					S.AddLin10(575, 50, 575, 150);

					S.PresetRoot(-0.3);
					S.AddArc01(625, 150, 750, 275/*, -0.3*/);

					S.AddLin00(175, 150, 625, 150);

					S.AddArc00(50, 275, 175, 150);

					S.AddArc00(175, 400, 50, 275);

					S.AddLin00(175, 400, 625, 400);

					S.AddArc00(625, 400, 750, 525);

					S.AddArc00(750, 525, 625, 650);

					S.AddLin00(175, 650, 625, 650);

					S.PresetRoot(-0.3);
					S.AddArc01(175, 650, 50, 525/*, -0.3*/);

					S.AddLin01(225, 650, 225, 750);

					S.AddLin01(575, 650, 575, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# № 
		protected class numbaChr : Chr {
			public numbaChr() { Str = Name = "№"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin01(50, 225, 50, 750);

					S.AddLin11(50, 225, 400, 750);

					S.AddLin00(400, 225, 400, 750);

					S.AddArc00(400, 225, 575, 50);

					S.AddArc00(575, 50, 750, 225);

					S.AddArc00(750, 225, 575, 400);

					S.AddArc00(575, 400, 400, 225);

					S.AddLin11(575, 575, 750, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# # 
		protected class sharpChr : Chr {
			public sharpChr() { Str = Name = "#"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddLin11(225, 50, 225, 750);

					S.AddLin11(575, 50, 575, 750);

					S.AddLin11(50, 225, 750, 225);

					S.AddLin11(50, 575, 750, 575);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# © 
		protected class copyChr : Chr {
			public copyChr() : base('©') { Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= 2.0;
					S.Thickness = D;

					S.AddResizeMovA(XY: 100);
					S.AddArc00(400, 750, 50, 400);

					S.AddArc00(50, 400, 400, 50);

					S.AddArc00(400, 50, 750, 400);

					S.AddArc00(750, 400, 400, 750);

					D *= 2.0;
					S.Thickness = D;
					S.SetResizeMovA(WH: 0.5, XY: 300);
					S.AddArc00(400, 750, 50, 400);

					S.AddArc00(50, 400, 400, 50);

					S.PresetRoot(-0.5);
					S.AddArc01(400, 50, 750, 400/*, -0.5*/);

					S.PresetRoot(0.5);
					S.AddArc10(750, 400, 400, 750/*, 0.5*/);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# ® 
		protected class registeredChr : Chr {
			public registeredChr() : base('®') { Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= 2.0;
					S.Thickness = D;

					S.AddResizeMovA(XY: 100);
					S.AddLin00(50, 225, 50, 575);

					S.AddArc00(50, 225, 225, 50);

					S.AddLin00(225, 50, 575, 50);

					S.AddArc00(575, 50, 750, 225);

					S.AddArc00(225, 750, 50, 575);

					S.AddLin00(750, 225, 750, 575);

					S.AddArc00(750, 575, 575, 750);

					S.AddLin00(225, 750, 575, 750);

					D *= 2.0;
					S.Thickness = D;
					S.SetResizeMovA(WH: 0.5, XY: 300);
					S.AddLin11(50, 50, 50, 750);

					S.AddLin00(50, 50, 750, 50);

					S.AddArc10(750, 50, 275, 525);

					S.AddLin00(50, 525, 275, 525);

					S.AddLin01(275, 525, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# ™ 
		protected class trademarkChr : Chr {
			public trademarkChr() : base('™') { Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= 2.0;
					S.Thickness = D;

					S.AddResizeMovA(XY: 100);
					S.AddLin00(50, 225, 50, 575);

					S.AddArc00(50, 225, 225, 50);

					S.AddLin00(225, 50, 575, 50);

					S.AddArc00(575, 50, 750, 225);

					S.AddArc00(225, 750, 50, 575);

					S.AddLin00(750, 225, 750, 575);

					S.AddArc00(750, 575, 575, 750);

					S.AddLin00(225, 750, 575, 750);

					D *= 2.0;
					S.Thickness = D;
					S.SetResizeMovA(WH: 0.5, XY: 300);
					S.AddLin11(50, 50, 750, 50);

					S.AddLin00(400, 50, 400, 750);

					S.AddLin01(50, 400, 50, 750);

					S.AddLin10(50, 400, 400, 750);

					S.AddLin11(400, 750, 750, 400);

					S.AddLin01(750, 400, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# % 
		protected class persentChr : Chr {
			public persentChr() : base('%') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddRotate(400, -25, 250, 500);
					S.AddArc10(150, 350 + 100, 150 - 100, 350);

					S.AddArc01(150 - 100, 350, 150, 350 - 100);

					S.AddArc10(350, 650 - 100, 350 + 100, 650);

					S.AddArc01(350 + 100, 650, 350, 650 + 100);
					S.CutRotate();

					//var L = new Bezier(400, -25, 100, 1025);

					//S.IsBonesUse = true;
					S.AddOrc(400, -25, 25);
					//S.BaseIntersectBones(L, out var M);

					S.AddOrc(100, 1025, 25);
					//S.LastIntersectBones(L, out var E);
					//S.IsBonesUse = false;

					S.PresetRoot(0.02289931874165918, -0.022899318741659291);
					S.AddLin00(400, -25, 100, 1025);

				}
				return S;
			}
		}
		#endregion
		#region #class# / 
		protected class slashChr : Chr {
			public slashChr() : base('/') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;
					//var L = new Bezier(400, -25, 100, 1025);

					//S.IsBonesUse = true;
					S.AddOrc(400, -25, 25);
					//S.BaseIntersectBones(L, out var M);

					S.AddOrc(100, 1025, 25);
					//S.LastIntersectBones(L, out var E);
					//S.IsBonesUse = false;

					//S.AddLin00(x0, y0, x1, y1);
					S.PresetRoot(0.02289931874165918, -0.022899318741659291);
					S.AddLin00(400, -25, 100, 1025);

				}
				return S;
			}
		}
		#endregion
		#region #class# \ 
		protected class backslashChr : Chr {
			public backslashChr() : base('\\') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;
					//var L = new Bezier(100, -25, 400, 1025);

					//S.IsBonesUse = true;
					S.AddOrc(100, -25, 25);
					//S.BaseIntersectBones(L, out var M);

					S.AddOrc(400, 1025, 25);
					//S.LastIntersectBones(L, out var E);
					//S.IsBonesUse = false;

					S.PresetRoot(0.022899318741659208, -0.022899318741659291);
					S.AddLin00(100, -25, 400, 1025);

				}
				return S;
			}
		}
		#endregion
		#region #class# \x0301 
		///// <summary>Ударение</summary>
		//protected class comChr : Chr {
		//	public comChr() : base('\x0301') { Width = 500; Height = 1000; }
		//	public override PathSource Get(double D = 0, PathSource Source = null) {
		//		var S = Source ?? new PathSource(500, 1000);
		//		if (D > 0) {
		//			D /= UD;
		//			S.Thickness = D;
		//			
		//			S.AddLin11(150, 575, 350, 425);
		//			
		//		}
		//		return S;
		//	}
		//}
		#endregion
		#region #class# , 
		protected class commaChr : Chr {
			public commaChr() : base(',') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddRotate(51.5, 88, 500);
					S.AddOrc(88, 300, 25);

					S.PresetRoot(0.075);
					S.AddArc01(88, 300, 288, 500/*, 0.075*/);
					S.CutRotate();

				}
				return S;
			}
		}
		#endregion
		#region #class# ; 
		protected class semicolonChr : Chr {
			public semicolonChr() : base(';') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddOrc(162, 500, 25);

					S.AddRotate(51.5, 162, 500);
					S.AddOrc(162, 300, 25);

					S.PresetRoot(0.075);
					S.AddArc01(162, 300, 362, 500/*, 0.075*/);
					S.CutRotate();

				}
				return S;
			}
		}
		#endregion
		#region #class# • 
		protected class bulletChr : Chr {
			public bulletChr() : base('•') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddOrc(250, 500, 75);

				}
				return S;
			}
		}
		#endregion
		#region #class# . 
		protected class periodChr : Chr {
			public periodChr() : base('.') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddOrc(250, 500, 25);

				}
				return S;
			}
		}
		#endregion
		#region #class# · 
		protected class periodcenteredChr : Chr {
			public periodcenteredChr() : base('·') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddOrc(250, 500, 25);

				}
				return S;
			}
		}
		#endregion
		#region #class# : 
		protected class colonChr : Chr {
			public colonChr() : base(':') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddOrc(250, 375, 25);

					S.AddOrc(250, 625, 25);

				}
				return S;
			}
		}
		#endregion
		#region #class# … 
		protected class ellipsisChr : Chr {
			public ellipsisChr() : base('…') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddOrc(358, 500, 25);

					S.AddOrc(142, 375, 25);

					S.AddOrc(142, 625, 25);

				}
				return S;
			}
		}
		#endregion
		#region #class# - 
		protected class minusChr : Chr {
			public minusChr() : base('-') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin11(100, 500, 400, 500);

				}
				return S;
			}
		}
		#endregion
		#region #class# ‑ 
		protected class hyphennobreakChr : Chr {
			public hyphennobreakChr() : base('‑') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin00(0, 500, 500, 500);

				}
				return S;
			}
		}
		#endregion
		#region #class# ‐ 
		protected class hyphenChr : Chr {
			public hyphenChr() : base('‐') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin11(50, 500, 450, 500);

				}
				return S;
			}
		}
		#endregion
		#region #class# ‒ 
		protected class figuredashChr : Chr {
			public figuredashChr() : base('‒') { Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin10(100, 500, 1000, 500);

				}
				return S;
			}
		}
		#endregion
		#region #class# – 
		protected class endashChr : Chr {
			public endashChr() : base('–') { Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin01(0, 500, 900, 500);

				}
				return S;
			}
		}
		#endregion
		#region #class# — 
		protected class emdashChr : Chr {
			public emdashChr() : base('—') { Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin00(0, 500, 1000, 500);

				}
				return S;
			}
		}
		#endregion
		#region #class# + 
		protected class plusChr : Chr {
			public plusChr() : base('+') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin11(100, 500, 400, 500);

					S.AddLin11(250, 350, 250, 650);

				}
				return S;
			}
		}
		#endregion
		#region #class# * 
		protected class asteriskChr : Chr {
			public asteriskChr() : base('*') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin11(250, 350, 250, 650);

					S.AddRotate(60, 250, 500);
					S.AddLin11(250, 350, 250, 650);

					S.SetRotate(-60, 250, 500);
					S.AddLin11(250, 350, 250, 650);
					S.CutRotate();

				}
				return S;
			}
		}
		#endregion
		#region #class# ± 
		protected class plusminusChr : Chr {
			public plusminusChr() : base('±') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin11(100, 400, 400, 400);

					S.AddLin11(250, 250, 250, 550);

					S.AddLin11(100, 700, 400, 700);

				}
				return S;
			}
		}
		#endregion
		#region #class# ( 
		protected class parenLeftChr : Chr {
			public parenLeftChr() : base('(') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;
					//S.FigureBegin();
					//var CB = S.AddArc(100, 500, 500, -50).IntersectLine(X1 - R, Y1, X2 - R, Y2);
					//var BB = 1.0 - CB.root;

					S.PresetRoot(-0.19760141239685169);
					S.AddArc00(100, 500, 500, -50/*, -0.19760141239685169*/);

					S.PresetRoot(0.19760141239685169);
					S.AddArc00(500, 1050, 100, 500/*, 0.19760141239685169*/);

					S.AddOrc(400, -25, 25);

					S.AddOrc(400, 1025, 25);

				}
				return S;
			}
		}
		#endregion
		#region #class# ) 
		protected class parenRightChr : Chr {
			public parenRightChr() : base(')') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.PresetRoot(0.19760141239685169);
					S.AddArc00(0, -50, 400, 500/*, 0.19760141239685169*/);

					S.PresetRoot(-0.19760141239685169);
					S.AddArc00(400, 500, 0, 1050/*, -0.19760141239685169*/);

					S.AddOrc(100, -25, 25);

					S.AddOrc(100, 1025, 25);

				}
				return S;
			}
		}
		#endregion
		#region #class# { 
		protected class braceLeltChr : Chr {
			public braceLeltChr() : base('{') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					const double R = 25;
					const double X1 = 400;
					const double Y1 = -25;
					const double X2 = 400;
					const double Y2 = 1025;
					D /= UD;
					S.Thickness = D;
					//S.FigureBegin();
					//var CB = S.AddArc(200, 300, 500, -50).IntersectLine(X1 - R, Y1, X2 - R, Y2);
					//var BB = 1.0 - CB.root;

					S.PresetRoot(0.26924939404799664);
					S.AddArc00(500, 1050, 200, 700/*, 0.26924939404799664*/);

					S.AddArc10(100, 600, 200, 700);

					S.AddLin00(200, 500, 100, 600);

					S.AddLin01(100, 400, 200, 500);

					S.AddArc01(200, 300, 100, 400);

					S.PresetRoot(-0.26924939404799664);
					S.AddArc00(200, 300, 500, -50/*, -0.26924939404799664*/);

					S.AddOrc(400, -25, 25);

					S.AddOrc(400, 1025, 25);

				}
				return S;
			}
		}
		#endregion
		#region #class# } 
		protected class braceRightChr : Chr {
			public braceRightChr() : base('}') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.PresetRoot(0.26924939404799664);
					S.AddArc00(0, -50, 300, 300/*, 0.26924939404799664*/);

					S.AddArc10(400, 400, 300, 300);

					S.AddLin00(400, 400, 300, 500);

					S.AddLin10(300, 500, 400, 600);

					S.AddArc01(300, 700, 400, 600);

					S.PresetRoot(-0.26924939404799664);
					S.AddArc00(300, 700, 0, 1050/*, -0.26924939404799664*/);

					S.AddOrc(100, -25, 25);

					S.AddOrc(100, 1025, 25);

				}
				return S;
			}
		}
		#endregion
		#region #class# [ 
		protected class bracketLeftChr : Chr {
			public bracketLeftChr() : base('[') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin11(150, 75, 150, 925);

					S.AddLin00(150, 75, 250, -25);

					S.AddLin00(150, 925, 250, 1025);

					S.AddLin10(250, -25, 375, -25);

					S.AddLin10(250, 1025, 375, 1025);

					S.AddOrc(400, -25, 25);

					S.AddOrc(400, 1025, 25);

				}
				return S;
			}
		}
		#endregion
		#region #class# ] 
		protected class bracketRightChr : Chr {
			public bracketRightChr() : base(']') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin11(350, 75, 350, 925);

					S.AddLin00(250, -25, 350, 75);

					S.AddLin00(250, 1025, 350, 925);

					S.AddLin01(125, -25, 250, -25);

					S.AddLin01(125, 1025, 250, 1025);

					S.AddOrc(100, -25, 25);

					S.AddOrc(100, 1025, 25);

				}
				return S;
			}
		}
		#endregion
		#region #class# | 
		protected class barChr : Chr {
			public barChr() : base('|') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin00(250, 0, 250, 1000);

					S.AddOrc(250, -25, 25);

					S.AddOrc(250, 1025, 25);

				}
				return S;
			}
		}
		#endregion
		#region #class# ¦ 
		protected class brokenbarChr : Chr {
			public brokenbarChr() : base('¦') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin00(250, 0, 250, 300);

					S.AddLin00(250, 700, 250, 1000);

					S.AddOrc(250, 325, 25);

					S.AddOrc(250, 675, 25);

					S.AddOrc(250, -25, 25);

					S.AddOrc(250, 1025, 25);

				}
				return S;
			}
		}
		#endregion
		#region #class# < 
		protected class lessChr : Chr {
			public lessChr() : base('<') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin01(125, 500, 375, 250);

					S.AddLin11(125, 500, 375, 750);

				}
				return S;
			}
		}
		#endregion
		#region #class# > 
		protected class greaterChr : Chr {
			public greaterChr() : base('>') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin10(125, 250, 375, 500);

					S.AddLin11(125, 750, 375, 500);

				}
				return S;
			}
		}
		#endregion
		#region #class# = 
		protected class equalsChr : Chr {
			public equalsChr() : base('=') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin11(100, 375, 400, 375);

					S.AddLin11(100, 625, 400, 625);

				}
				return S;
			}
		}
		#endregion
		#region #class# ≤ 
		protected class lessequalChr : Chr {
			public lessequalChr() : base('≤') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin01(100, 150 + 375, 400, 150 + 75);

					S.AddLin11(100, 150 + 375, 400, 150 + 375);

					S.AddLin11(100, 150 + 625, 400, 150 + 625);

				}
				return S;
			}
		}
		#endregion
		#region #class# ≥ 
		protected class greaterequalChr : Chr {
			public greaterequalChr() : base('≥') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin11(100, 150 + 75, 400, 150 + 375);

					S.AddLin10(100, 150 + 375, 400, 150 + 375);

					S.AddLin11(100, 150 + 625, 400, 150 + 625);

				}
				return S;
			}
		}
		#endregion
		#region #class# ? 
		protected class questionChr : Chr {
			public questionChr() : base('?') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.PresetRoot(0.5);
					S.AddArc10(100, 275, 250, 125/*, 0.5*/);

					S.AddArc00(250, 125, 400, 275);

					S.AddArc00(400, 275, 250, 425);

					S.AddArc00(150, 525, 250, 425);

					S.AddArc00(250, 625, 150, 525);

					S.PresetRoot(0.5);
					S.AddArc10(350, 525, 250, 625/*, 0.5*/);

					S.AddOrc(250, 850, 25);

				}
				return S;
			}
		}
		#endregion
		#region #class# ! 
		protected class exclamChr : Chr {
			public exclamChr() : base('!') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin11(250, 125, 250, 625);

					S.AddOrc(250, 850, 25);

				}
				return S;
			}
		}
		#endregion
		#region #class# & 
		protected class ampersandChr : Chr {
			public ampersandChr() : base('&') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;


					S.AddArc00(125, 250, 250, 125);

					S.AddArc00(250, 125, 375, 250);


					S.AddYrc00(375, 250, 125, 750);

					S.AddYrc00(375, 750, 125, 250);


					S.AddArc00(375, 750, 250, 875);

					S.AddArc00(250, 875, 125, 750);


					S.AddOrc(250, 500, 25);


					S.AddRotate(-60, 250, 500);
					S.AddArc01(250, 500, 150, 400);

					S.AddArc01(250, 500, 350, 600);
					S.CutRotate();

				}
				return S;
			}
		}
		#endregion
		#region #class# @ 
		protected class atChr : Chr {
			public atChr() { Str = Name = "@"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddResizeMovA(XY: UXY, WH: UWH);
					S.AddArc00(400, 575, 225, 400);

					S.AddArc00(225, 400, 400, 225);

					S.AddLin00(400, 225, 575, 225);

					S.AddLin10(575, 225, 575, 575);

					S.AddLin01(400, 575, 750, 575);

					S.AddLin00(750, 575, 750, 225);

					S.AddArc00(575, 50, 750, 225);

					S.AddLin00(400, 50, 575, 50);

					S.AddArc00(50, 400, 400, 50);

					S.AddArc00(400, 750, 50, 400);

					S.AddLin01(400, 750, 750, 750);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
		#region #class# ' 
		protected class quoteChr : Chr {
			public quoteChr() : base('\'') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin10(300, 425, 225, 500);

					S.AddLin10(250, 425, 275, 500);

					S.AddLin11(275, 500, 200, 575);

					S.AddLin11(225, 500, 250, 575);

				}
				return S;
			}
		}
		#endregion
		#region #class# " 
		protected class quote2Chr : Chr {
			public quote2Chr() : base('"') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin10(375, 425, 400, 500);

					S.AddLin11(400, 500, 325, 575);

					S.AddLin10(175, 425, 100, 500);

					S.AddLin11(100, 500, 125, 575);

				}
				return S;
			}
		}
		#endregion
		#region #class# « 
		protected class guillemotLeftChr : Chr {
			public guillemotLeftChr() : base('«') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin10(175, 425, 100, 500);

					S.AddLin11(100, 500, 125, 575);

					S.AddLin10(400, 425, 325, 500);

					S.AddLin11(325, 500, 350, 575);

				}
				return S;
			}
		}
		#endregion
		#region #class# » 
		protected class guillemotRightChr : Chr {
			public guillemotRightChr() : base('»') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin10(375, 425, 400, 500);

					S.AddLin11(400, 500, 325, 575);

					S.AddLin10(150, 425, 175, 500);

					S.AddLin11(175, 500, 100, 575);

				}
				return S;
			}
		}
		#endregion
		#region #class# ` 
		protected class graveChr : Chr {
			public graveChr() : base('`') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddRotate(-45, 250, 500);
					S.AddLin10(250, 425, 225, 500);

					S.AddLin10(200, 425, 275, 500);

					S.AddLin11(275, 500, 250, 575);

					S.AddLin11(225, 500, 300, 575);
					S.CutRotate();

				}
				return S;
			}
		}
		#endregion
		#region #class# ´ 
		protected class acuteChr : Chr {
			public acuteChr() : base('´') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddRotate(45, 250, 500);
					S.AddLin10(300, 425, 225, 500);

					S.AddLin10(250, 425, 275, 500);

					S.AddLin11(275, 500, 200, 575);

					S.AddLin11(225, 500, 250, 575);
					S.CutRotate();

				}
				return S;
			}
		}
		#endregion
		#region #class# ~ 
		protected class asciitildeChr : Chr {
			public asciitildeChr() : base('~') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddRotate(-53.1, 250, 500);
					S.AddArc10(150, 400, 250, 500);

					S.AddArc10(350, 600, 250, 500);
					S.CutRotate();

				}
				return S;
			}
		}
		#endregion
		#region #class# ˜ 
		protected class tildeChr : Chr {
			public tildeChr() : base('˜') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddRotate(-53.1, 250, 500);
					S.AddArc10(150, 400, 250, 500);

					S.AddArc10(350, 600, 250, 500);
					S.CutRotate();

				}
				return S;
			}
		}
		#endregion
		#region #class# × 
		protected class mulChr : Chr {
			public mulChr() : base('×') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddRotate(45, 250, 500);
					S.AddLin11(100, 500, 400, 500);

					S.AddLin11(250, 350, 250, 650);
					S.CutRotate();

				}
				return S;
			}
		}
		#endregion
		#region #class# ^ 
		protected class circumChr : Chr {
			public circumChr() : base('^') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin01(250, 425, 400, 575);

					S.AddLin11(250, 425, 100, 575);

				}
				return S;
			}
		}
		#endregion
		#region #class# _ 
		protected class underscoreChr : Chr {
			public underscoreChr() : base('_') { Width = 500; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;

					S.AddLin01(250, 575, 400, 425);

					S.AddLin11(250, 575, 100, 425);

				}
				return S;
			}
		}
		#endregion
		#endregion
		#region #class# 0x 
		//protected class hexStr : Chr {
		//	public hexStr() : base() { Str = Name = "0x"; Width = 1000; Height = 1000; }
		//	public override PathSource Get(double D = 0, PathSource Source = null) {
		//		var S = Source ?? new PathSource(1000, 1000);
		//		if (D > 0) {
		//			D /= UD;
		//			
		//			S.AddResizeMovA(XY: UXY, WH: UWH);
		//			S.AddLin00(50, 225, 50, 575);
		//			
		//			S.AddArc00(50, 225, 225, 50);
		//			
		//			S.AddLin00(225, 50, 575, 50);
		//			
		//			S.AddArc00(575, 50, 750, 225);
		//			
		//			S.AddArc00(225, 750, 50, 575);
		//			
		//			S.AddLin00(750, 225, 750, 575);
		//			
		//			S.AddArc00(750, 575, 575, 750);
		//			
		//			S.AddLin00(225, 750, 575, 750);
		//			S.CutResize();
		//			
		//			D *= 2;
		//			S.AddResizeMovA(0.5, X: 300, Y: 300);
		//			S.AddLin11(50, 50, 750, 750);
		//			
		//			S.AddLin11(750, 50, 50, 750);
		//			S.CutResize();
		//			
		//		}
		//		return S;
		//	}
		//}
		#endregion
		#region #class# 0b 
		//protected class binStr : Chr {
		//	public binStr() : base() { Str = Name = "0b"; Width = 1000; Height = 1000; }
		//	public override PathSource Get(double D = 0, PathSource Source = null) {
		//		var S = Source ?? new PathSource(1000, 1000);
		//		if (D > 0) {
		//			D /= UD;
		//			
		//			S.AddResizeMovA(XY: UXY, WH: UWH);
		//			S.AddLin00(50, 225, 50, 575);
		//			
		//			S.AddArc00(50, 225, 225, 50);
		//			
		//			S.AddLin00(225, 50, 575, 50);
		//			
		//			S.AddArc00(575, 50, 750, 225);
		//			
		//			S.AddArc00(225, 750, 50, 575);
		//			
		//			S.AddLin00(750, 225, 750, 575);
		//			
		//			S.AddArc00(750, 575, 575, 750);
		//			
		//			S.AddLin00(225, 750, 575, 750);
		//			S.CutResize();
		//			
		//			D *= 2;
		//			S.AddResizeMovA(0.5, X: 300, Y: 300);
		//			S.AddArc00(275, 750, 50, 525);
		//			
		//			S.AddLin10(50, 50, 50, 525);
		//			
		//			S.AddLin10(275, 300, 525, 300);
		//			
		//			S.AddArc00(525, 300, 750, 525);
		//			
		//			S.AddArc00(750, 525, 525, 750);
		//			
		//			S.AddLin00(275, 750, 525, 750);
		//			S.CutResize();
		//			
		//		}
		//		return S;
		//	}
		//}
		#endregion
		#region #string# WholemyStr 
		protected class WholemyStr : Chr {
			public WholemyStr() { Str = Name = "Wholemy"; Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= UD;
					S.Thickness = D;
					double NM = 80 / UD;
					double NL = 60 / UD;
					S.AddResizeMoved();

					S.AddOrc(500, 500, 100 / UD);
					// Верхние средние кружки Центр
					S.AddOrc(500, 500 - 180.5, NM);
					// Правые средние кружки Центр
					S.AddOrc(500 + 180.5, 500, NM);
					// Нижние средние кружки Центр
					S.AddOrc(500, 500 + 180.5, NM);
					// Левые средние кружки Центр
					S.AddOrc(500 - 180.5, 500, NM);

					// Верхние средние кружки Лево
					S.AddOrc(500 - 123.2, 500 - 283.5, NM);
					// Верхние средние кружки Право
					S.AddOrc(500 + 123.2, 500 - 283.5, NM);
					// Правые средние кружки Верх
					S.AddOrc(500 + 283.5, 500 - 123.2, NM);
					// Правые средние кружки Низ
					S.AddOrc(500 + 283.5, 500 + 123.2, NM);
					// Нижние средние кружки Право
					S.AddOrc(500 + 123.2, 500 + 283.5, NM);
					// Нижние средние кружки Лево
					S.AddOrc(500 - 123.2, 500 + 283.5, NM);
					// Левые средние кружки Низ
					S.AddOrc(500 - 283.5, 500 + 123.2, NM);
					// Левые средние кружки Верх
					S.AddOrc(500 - 283.5, 500 - 123.2, NM);

					// Верхние малые кружки 1
					S.AddOrc(500 - 228.915, 500 - 375.83, NL);
					// Верхние малые кружки 2
					S.AddOrc(500 - 118.88, 500 - 423.77, NL);
					// Верхние малые кружки 3
					S.AddOrc(500, 500 - 440, NL);
					// Верхние малые кружки 4
					S.AddOrc(500 + 118.88, 500 - 423.77, NL);
					// Верхние малые кружки 5
					S.AddOrc(500 + 228.915, 500 - 375.83, NL);

					// Правые малые кружки 1
					S.AddOrc(500 + 375.83, 500 - 228.915, NL);
					// Правые малые кружки 2
					S.AddOrc(500 + 423.77, 500 - 118.88, NL);
					// Правые малые кружки 3
					S.AddOrc(500 + 440, 500, NL);
					// Правые малые кружки 4
					S.AddOrc(500 + 423.77, 500 + 118.88, NL);
					// Правые малые кружки 5
					S.AddOrc(500 + 375.83, 500 + 228.915, NL);

					// Нижние малые кружки 5
					S.AddOrc(500 + 228.915, 500 + 375.83, NL);
					// Нижние малые кружки 4
					S.AddOrc(500 + 118.88, 500 + 423.77, NL);
					// Нижние малые кружки 3
					S.AddOrc(500, 500 + 440, NL);
					// Нижние малые кружки 2
					S.AddOrc(500 - 118.88, 500 + 423.77, NL);
					// Нижние малые кружки 1
					S.AddOrc(500 - 228.915, 500 + 375.83, NL);

					// Левые малые кружки 5
					S.AddOrc(500 - 375.83, 500 + 228.915, NL);
					// Левые малые кружки 4
					S.AddOrc(500 - 423.77, 500 + 118.88, NL);
					// Левые малые кружки 3
					S.AddOrc(500 - 440, 500, NL);
					// Левые малые кружки 2
					S.AddOrc(500 - 423.77, 500 - 118.88, NL);
					// Левые малые кружки 1
					S.AddOrc(500 - 375.83, 500 - 228.915, NL);
					S.CutResize();

				}
				return S;
			}
		}
		#endregion
	}
}
