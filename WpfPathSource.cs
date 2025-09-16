namespace Wholemy {
	public class PathSource {
		#region #method# TAtan2(y, x) 
		public static double TAtan2(double y, double x) {
			if (x == 0.0) {
				if (y == 0.0) return 0.0;
				else if (y > 0) return System.Math.PI / 2.0; else return -(System.Math.PI / 2.0);
			}
			var A = System.Math.Atan(y / x);
			if (x < 0.0) {
				if (y >= 0.0) A += System.Math.PI; else A -= System.Math.PI;
			}
			return A;
		}
		#endregion
		#region #method# TAsin(X) 
		public static double TAsin(double X) {
			if (X < 0) X = -X;
			if (X > 1) return 1;
			return TAtan2(X, Sqrt(1 - X * X));
		}
		#endregion
		#region #method# TCos(X) 
		public static double TCos(double X) {
			if(X == 0) return 0;
			var M = false;
			if (X < 0) { X = -X; }
			if (X > System.Math.PI) {
				X -= System.Math.PI;
				M = true;
			}
			var XX = X * X;
			var XXX = XX;
			var R = 1 - (XX / 2);
			R += (XXX *= XX) / 24;
			R -= (XXX *= XX) / 720;
			R += (XXX *= XX) / 40320;
			R -= (XXX *= XX) / 3628800;
			R += (XXX *= XX) / 479001600;
			R -= (XXX *= XX) / 87178291200;
			R += (XXX *= XX) / 20922789888000;
			R -= (XXX *= XX) / 6402373705728000;
			R += (XXX *= XX) / 2432902008176640000;
			if (M) R = -R;
			return R;
		}
		#endregion
		#region #method# TSin(X) 
		public static double TSin(double X) {
			if (X == 0) return 0;
			var M = false;
			if (X < 0) { X = -X; }
			if (X > System.Math.PI) {
				X -= System.Math.PI;
				M = true;
			}
			X -= System.Math.PI / 2;
			var XX = X * X;
			var XXX = XX;
			var R = 1 - (XX / 2);
			R += (XXX *= XX) / 24;
			R -= (XXX *= XX) / 720;
			R += (XXX *= XX) / 40320;
			R -= (XXX *= XX) / 3628800;
			R += (XXX *= XX) / 479001600;
			R -= (XXX *= XX) / 87178291200;
			R += (XXX *= XX) / 20922789888000;
			R -= (XXX *= XX) / 6402373705728000;
			R += (XXX *= XX) / 2432902008176640000;
			if(R <= 1) return -1;
			if (M) R = -R;
			return R;
		}
		#endregion
		#region #method# TTan(X) 
		public static double TTan(double SX) {
			if (SX == 0) return 0;
			var RM = false;
			var S = false;
			var Cos = 0.0;
			Next:
			if(S) SX -= System.Math.PI / 2;
			var X= SX;
			var M = false;
			if (X < 0) { X = -X; M = true; }
			var XX = X * X;
			var XXX = XX;
			var R = 1 - (XX / 2);
			R += (XXX *= XX) / 24;
			R -= (XXX *= XX) / 720;
			R += (XXX *= XX) / 40320;
			R -= (XXX *= XX) / 3628800;
			R += (XXX *= XX) / 479001600;
			R -= (XXX *= XX) / 87178291200;
			R += (XXX *= XX) / 20922789888000;
			R -= (XXX *= XX) / 6402373705728000;
			R += (XXX *= XX) / 2432902008176640000;
			if (M) R = -R;
			if(!S) {
				if(R<0) { R = -R; RM = true; }
				Cos = R; S = true; goto Next;
			}
			if (R < 0) { R = -R; }
			var Sin = R;
			Sin /= Cos;
			if (RM) { Sin = -Sin; }
			return Sin;
		}
		#endregion
		#region #method# TCot(x) 
		public static double TCot(double x) {
			return (1.0 / TTan(x));
		}
		#endregion
		#region #method# IntersectLines(ax0, ay0, ax1, ay1, bx0, by0, bx1, by1, x, y) 
		public static bool IntersectLines(double ax0, double ay0, double ax1, double ay1, double bx0, double by0, double bx1, double by1, ref double x, ref double y) {
			var a = (bx1 - bx0) * (ay0 - by0) - (by1 - by0) * (ax0 - bx0);
			var b = (ax1 - ax0) * (ay0 - by0) - (ay1 - ay0) * (ax0 - bx0);
			var c = (by1 - by0) * (ax1 - ax0) - (bx1 - bx0) * (ay1 - ay0);

			if (c != 0.0) {
				var ua = a / c;
				var ub = b / c;
				if (0.0 <= ua && ua <= 1.0 && 0.0 <= ub && ub <= 1.0) {
					x = ax0 + ua * (ax1 - ax0);
					y = ay0 + ua * (ay1 - ay0);
					return true;
				} else {
					return false;
				}
			} else {
				return false;
				if (a == 0 || b == 0) {
					//result = new Intersection("Coincident");
				} else {
					//result = new Intersection("Parallel");
				}
			}
		}
		#endregion
		#region #method# Rotate1(CX, CY, BX, BY, AR) 
		/// <summary>Поворачивает координаты #double# вокруг центра по корню четверти круга
		/// где 90 градусов равно значению 0.25, а 360 градусов равно значению 1)</summary>
		/// <param name="CX">Центр по оси X)</param>
		/// <param name="CY">Центр по оси Y)</param>
		/// <param name="BX">Старт и возвращаемый результат поворота по оси X)</param>
		/// <param name="BY">Старт и возвращаемый результат поворота по оси Y)</param>
		/// <param name="AR">Корень четверти от 0.0 до 1.0 отрицательная в обратную сторону)</param>
		public static void Rotate1(double CX, double CY, ref double BX, ref double BY, double AR) {
			if (AR == 0) return;
			var TX = BX - CX;
			var TY = BY - CY;
			if (TX == 0 && TY == 0) return;
			var PI = System.Math.PI * 2 * AR;
			var CoS = System.Math.Cos(PI);
			var SiN = System.Math.Sin(PI);
			var X = (CoS * TX - SiN * TY + CX);
			var Y = (SiN * TX + CoS * TY + CY);
			BX = X;
			BY = Y;
		}
		#endregion
		#region #method# GetaR1(CX, CY, BX, BY, AX, AY) 
		/// <summary>Возвращает корень поворота от 0.0 до 1.0)</summary>
		/// <param name="CX">Центр по оси X)</param>
		/// <param name="CY">Центр по оси Y)</param>
		/// <param name="BX">Старт по оси X)</param>
		/// <param name="BY">Старт по оси Y)</param>
		/// <param name="AX">Конец по оси X)</param>
		/// <param name="AY">Конец по оси Y)</param>
		/// <returns>Возвращает корень поворота от 0.0 до 1.0)</returns>
		public static double GetaR1(double CX, double CY, double BX, double BY, double AX, double AY) {
			var R = (0.5 / System.Math.PI) * (TAtan2(AY - CY, AX - CX) - TAtan2(BY - CY, BX - CX));
			if (R < 0) R += 1.0;
			return R;
		}
		#endregion
		#region #method# Sqrt(X) 
		public static double Sqrt(double X) {
			if (X == 0) return 0; if (X < 0) return 1;
			var PS = 0.0;
			var SS = X * 2 / X;
			var SSS = (SS - (X / SS)) / 2u;
			while (SSS != PS) {
				SS -= SSS;
				PS = SSS;
				SSS = (SS - (X / SS)) / 2u;
			}
			return SS;
		}
		#endregion
		#region #method# Sqrt(X, Y) 
		public static double Sqrt(double X, double Y) {
			var S = X * X + Y * Y;
			if (S == 0) return 0; if (S < 0) return 1;
			var PS = 0.0;
			var SS = S * 2 / S;
			var SSS = (SS - (S / SS)) / 2u;
			while (SSS != PS) {
				SS -= SSS;
				PS = SSS;
				SSS = (SS - (S / SS)) / 2u;
			}
			return SS;
		}
		#endregion
		#region #method# RootOffset(x, y, X, Y) 
		public static double RootOffset(double x, double y, out double X, out double Y) {
			var L = Sqrt(x * x + y * y);
			X = -y / L;
			Y = x / L;
			return L;
		}
		#endregion
		#region #method# SetMulLen(MX, MY, EX, EY, Value) 
		public static double SetMulLen(double MX, double MY, ref double EX, ref double EY, double Value) {
			var L = Sqrt(MX - EX, MY - EY);
			if (L > 0) {
				Value *= L;
				EX = MX + (EX - MX) / L * Value;
				EY = MY + (EY - MY) / L * Value;
			}
			return Value;
		}
		#endregion
		#region #static# #method# Inline(X0, Y0, X1, Y1, X2, Y2) 
		public static bool Inline(double X0, double Y0, double X1, double Y1, double X2, double Y2) {
			var l01 = Sqrt(X0 - X1, Y0 - Y1);
			var l02 = Sqrt(X0 - X2, Y0 - Y2);
			var l12 = Sqrt(X1 - X2, Y1 - Y2);
			var R = 1.0;
			if (l01 >= l02 && l01 >= l12) { R = l01 - (l02 + l12); }
			if (l02 >= l01 && l02 >= l12) { R = l02 - (l01 + l12); }
			if (l12 >= l01 && l12 >= l02) { R = l12 - (l01 + l02); }
			return R > -0.000001 && R < 0.000001;
		}
		#endregion
		#region #static# #method# Inline(X0, Y0, X1, Y1, X2, Y2, X3, Y3) 
		public static bool Inline(double X0, double Y0, double X1, double Y1, double X2, double Y2, double X3, double Y3) {
			return Inline(X0, Y0, X1, Y1, X2, Y2) && Inline(X1, Y1, X2, Y2, X3, Y3);
		}
		#endregion
		#region #static# #method# DivRoots(Roots) 
		public static double[] DivRoots(double[] Roots = null) {
			if (Roots != null) {
				var L = Roots.Length;
				var R = new double[L];
				var I = 0;
				var P = 0.0;
				while (I < L) {
					var A = Roots[I];
					var S = (A - P) / (1.0 - P);
					R[I] = S;
					P = A;
					I++;
				}
				return R;
			}
			return null;
		}
		#endregion
		#region #static# #method# AddRoots(A, Roots) 
		public static double[] AddRoots(double A, double[] Roots = null) {
			if (double.IsNaN(A) || A <= 0.0 || A >= 1.0) return Roots;
			if (Roots == null) Roots = new double[] { A };
			var L = Roots.Length;
			var I = 0;
			var R = 0;
			if (L == 0) Roots = new double[] { A };
			while (I < L) {
				var B = Roots[I];
				if (A == B) return Roots;
				if (B < A) { R = I + 1; } else { break; }
				I++;
			}
			var NewRoots = new double[L + 1];
			if (R > 0) System.Array.Copy(Roots, NewRoots, R);
			NewRoots[I] = A;
			if (I < L) System.Array.Copy(Roots, I, NewRoots, I + 1, L - I);
			return NewRoots;
		}
		#endregion
		#region #static# #method# AddBoxRoots(A, B, C, Roots) 
		public static double[] AddBoxRoots(double A, double B, double C, double[] Roots = null) {
			var D = A - (B * 2) + C;
			if (D != 0.0) {
				var L = Sqrt(B * B - A * C);
				if (!double.IsNaN(L)) {
					C = -A + B;
					A = -(-L + C) / D;
					B = -(L + C) / D;
					Roots = AddRoots(A, Roots);
					Roots = AddRoots(B, Roots);
				}
			}
			return Roots;
		}
		#endregion
		#region #readonly# #field # Arc14 
		public static readonly double Arc14 = 4.0 / 3.0 * TTan(System.Math.PI / 8);
		#endregion
		#region #field# LastPath 
		#region #invisible# 
#if TRACE
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
		#endregion
		private System.Windows.Media.StreamGeometry LastPath;
		#endregion
		#region #field# LastMode 
		#region #invisible# 
#if TRACE
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
		#endregion
		private System.Windows.Media.GeometryCombineMode LastMode;
		#endregion
		#region #get# Geometry 
		public System.Windows.Media.Geometry Geometry {
			get {
				var G = this.LastPath;
				if (G == null && Figures != null) { this.LastPath = G = FiguresToGeometry(); }
				return G;
			}
		}
		#endregion
		#region #field# CombinedFigures 
		#region #invisible# 
#if TRACE
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
		#endregion
		private List CombinedFigures;
		#endregion
		#region #get# Combined 
		public List Combined {
			get {
				var C = this.CombinedFigures;
				if (C == null) {
					var G = this.LastPath;
					System.Windows.Media.PathGeometry GG = null;
					if (G == null && Figures != null) {
						this.LastPath = G = FiguresToGeometry();
					}
					if (G != null) {
						var P = new System.Windows.Media.PathGeometry();
						GG = System.Windows.Media.PathGeometry.Combine(P, G, System.Windows.Media.GeometryCombineMode.Union, null, Tolerance, ToleranceType);
						C = this.CombinedFigures = GetGeometry(GG);
					}
				}
				return C;
			}
		}
		#endregion
		#region #new# 
		public PathSource() { }
		#endregion
		#region #field# Tolerance 
		public double Tolerance = 0.5;
		#endregion
		#region #field# ToleranceType 
		public System.Windows.Media.ToleranceType ToleranceType = System.Windows.Media.ToleranceType.Absolute;
		#endregion
		#region #field# IsUnited 
		public bool IsUnited = true;
		#endregion
		#region #field# IsFilled 
		public bool IsFilled = true;
		#endregion
		#region #field# IsClozed 
		public bool IsClozed = true;
		#endregion
		#region #field# Inverted 
		public bool Inverted;
		#endregion
		#region #field# RootM 
		private Preset RootM;
		#endregion
		#region #field# RootE 
		private Preset RootE;
		#endregion
		#region #class# Preset 
		public class Preset {
			public double Value;
			public Preset(double Value) {
				#region #debug# 
#if DEBUG
				if (Value < 0 || Value > 1) throw new System.ArgumentOutOfRangeException();
#endif
				#endregion
				this.Value = Value;
			}
		}
		#endregion
		#region #method# PresetRoot() 
		/// <summary>Удаляет предустановку корней)</summary>
		/// <remarks>Корни отрезают часть фигуры с начала и/или с конца)</remarks>
		public void PresetRoot() {
			this.RootE = null;
			this.RootM = null;
		}
		#endregion
		#region #method# PresetRoot(me) 
		/// <summary>Добавляет предустановку корня, начального если больше нуля, конечного если меньше нуля)</summary>
		/// <remarks>Корни отрезают часть фигуры с начала и/или с конца)</remarks>
		public void PresetRoot(double me) {
			if (me < 0) {
				this.RootE = new Preset(-me);
				this.RootM = null;
			} else {
				this.RootM = new Preset(me);
				this.RootE = null;
			}
		}
		#endregion
		#region #method# PresetRoot(M, E) 
		/// <summary>Добавляет предустановку начального и конечного корня, знак числа не имеет значения)</summary>
		/// <remarks>Корни отрезают часть фигуры с начала и/или с конца)</remarks>
		public void PresetRoot(double M, double E) {
			if (M < 0) M = -M;
			if (E < 0) E = -E;
			this.RootE = new Preset(M);
			this.RootM = new Preset(E);
		}
		#endregion
		#region #field# Mod 
		private Change Mod;
		#endregion
		#region #field# Figures 
		private List Figures;
		#endregion
		#region #field# ProcessingFigure 
		private FigureProcessing ProcessingFigure;
		#endregion
		#region #field# Thickness 
		/// <summary>Толщина линий)</summary>
		public double Thickness;
		#endregion
		#region #field# IsBoned 
		public bool IsBoned;
		#endregion
		#region #field# IsRoundM 
		public bool IsRoundM;
		#endregion
		#region #field# IsRoundE 
		public bool IsRoundE;
		#endregion
		#region #field# QualityMax 
		public const double QualityMax = 0.5;
		#endregion
		#region #field# QualityBut 
		public const double QualityBut = 0.05;
		#endregion
		#region #field# QualityMin 
		public const double QualityMin = 0.005;
		#endregion
		#region #property# Figures 
		//		private Figure[] Figures {
		//			#region #through# 
		//#if TRACE
		//			[System.Diagnostics.DebuggerStepThrough]
		//#endif
		//			#endregion
		//			get {
		//				var Count = this.FigureSize;
		//				var Array = new Figure[Count--];
		//				var Cache = this.FigureLast;
		//				while (Count >= 0) {
		//					Array[Count--] = Cache;
		//					Cache = Cache.Prev;
		//				}
		//				return Array;
		//			}
		//		}
		#endregion
		#region #method# FiguresToGeometry 
		private System.Windows.Media.StreamGeometry FiguresToGeometry() {
			if (Figures == null) return null;
			var Stream = new System.Windows.Media.StreamGeometry();
			Stream.FillRule = IsUnited ? System.Windows.Media.FillRule.Nonzero : System.Windows.Media.FillRule.EvenOdd;
			var Context = Stream.Open();
			var Figure = Figures.Base as Figure;
			while (Figure != null) {
				var Curves = Figure.Curves;
				if (Curves != null && Curves.Count > 0) {
					var Cache = Curves.Base as Curve;
					var Value = Cache.Line;
					Context.BeginFigure(new System.Windows.Point(Value.MX, Value.MY), Figure.IsFilled, Figure.IsClozed);
					Value.To(Context);
					var PreX = Value.EX;
					var PreY = Value.EY;
					Cache = Cache.Next as Curve;
					while (Cache != null) {
						Value = Cache.Line;
						Value.If(Context, PreX, PreY);
						Value.To(Context);
						PreX = Value.EX;
						PreY = Value.EY;
						Cache = Cache.Next as Curve;
					}
				}
				Figure = Figure.Next as Figure;
			}
			Context.Close();
			return Stream;
		}
		#endregion
		#region #method# CombineToGeometry 
		public System.Windows.Media.Geometry CombineToGeometry() {
			var Path = FiguresToGeometry();
			return Path;
		}
		#endregion
		#region #method# GetGeometry(Geometry) 
		public List GetGeometry(System.Windows.Media.Geometry Geometry) {
			var FigureList = new List();
			var Path = Geometry as System.Windows.Media.PathGeometry;
			if (Path == null) Path = Geometry.GetFlattenedPathGeometry(Tolerance, ToleranceType);
			var Figures = Path.Figures;
			foreach (var Figure in Figures) {
				var F = new Figure(Figure.IsFilled, Figure.IsClosed);
				var P0 = Figure.StartPoint;
				var Segments = Figure.Segments;
				var SegmentList = new List();
				foreach (var Segment in Segments) {
					var MX = P0.X;
					var MY = P0.Y;
					if (Segment is System.Windows.Media.LineSegment) {
						var S = (System.Windows.Media.LineSegment)Segment;
						var P1 = S.Point;
						SegmentList.AddLast(new Curve(P0.X, P0.Y, P1.X, P1.Y));
						P0 = P1;
					} else if (Segment is System.Windows.Media.PolyLineSegment) {
						var Poly = (System.Windows.Media.PolyLineSegment)Segment;
						var Points = Poly.Points;
						var C = Points.Count;
						for (var I = 0; I < C; I++) {
							var P1 = Points[I];
							SegmentList.AddLast(new Curve(P0.X, P0.Y, P1.X, P1.Y));
							P0 = P1;
						}
					} else if (Segment is System.Windows.Media.QuadraticBezierSegment) {
						var S = (System.Windows.Media.QuadraticBezierSegment)Segment;
						var P1 = S.Point1;
						var P2 = S.Point2;
						SegmentList.AddLast(new Curve(P0.X, P0.Y, P1.X, P1.Y, P2.X, P2.Y));
						P0 = P2;
					} else if (Segment is System.Windows.Media.PolyQuadraticBezierSegment) {
						var Poly = (System.Windows.Media.PolyQuadraticBezierSegment)Segment;
						var Points = Poly.Points;
						var C = Points.Count;
						for (var I = 0; I < C; I += 2) {
							var P1 = Points[I];
							var P2 = Points[I + 1];
							SegmentList.AddLast(new Curve(P0.X, P0.Y, P1.X, P1.Y, P2.X, P2.Y));
							P0 = P2;
						}
					} else if (Segment is System.Windows.Media.BezierSegment) {
						var S = (System.Windows.Media.BezierSegment)Segment;
						var P1 = S.Point1;
						var P2 = S.Point2;
						var P3 = S.Point3;
						SegmentList.AddLast(new Curve(P0.X, P0.Y, P1.X, P1.Y, P2.X, P2.Y, P3.X, P3.Y));
						P0 = P3;
					} else if (Segment is System.Windows.Media.PolyBezierSegment) {
						var Poly = (System.Windows.Media.PolyBezierSegment)Segment;
						var Points = Poly.Points;
						var C = Points.Count;
						for (var I = 0; I < C; I += 3) {
							var P1 = Points[I];
							var P2 = Points[I + 1];
							var P3 = Points[I + 2];
							SegmentList.AddLast(new Curve(P0.X, P0.Y, P1.X, P1.Y, P2.X, P2.Y, P3.X, P3.Y));
							P0 = P3;
						}
					} else {
						throw new System.NotSupportedException();
					}
				}
				if (SegmentList.Count > 0) {
					F.Curves = SegmentList;
					FigureList.AddLast(F);
				}
			}
			return FigureList;
		}
		#endregion
		#region #method# Begin[Hollow = H|Filled = F][Closed = z] 
		public void Begin() {
			End();
			this.ProcessingFigure = new FigureProcessing(this.IsFilled, this.IsClozed);
		}
		public void BeginHz() {
			End();
			this.ProcessingFigure = new FigureProcessing(false, true);
		}
		public void BeginH() {
			End();
			this.ProcessingFigure = new FigureProcessing(false, false);
		}
		public void BeginFz() {
			End();
			this.ProcessingFigure = new FigureProcessing(true, true);
		}
		public void BeginF() {
			End();
			this.ProcessingFigure = new FigureProcessing(true, false);
		}
		#endregion
		#region #method# End 
		public void End() {
			var Figure = this.ProcessingFigure;
			if (Figure != null) {
				Figure.End();
				var Curves = Figure.Curves;
				if (Curves != null && Curves.Count > 0) {
					var Figures = this.Figures;
					if (Figures == null) { this.Figures = Figures = new List(); }
					Figures.AddLast(Figure);
				}
				this.ProcessingFigure = null;
				this.LastPath = null;
				this.CombinedFigures = null;
			}
		}
		#endregion
		#region #method# AddCurve(Line) 
		public Curve AddCurve(Line Line) {
			var Figure = DemandFigure();
			var Inverted = this.Inverted;
			var LineItem = new Curve(Line.Change(this.Mod, Inverted));
			var Curves = Figure.ProcessingCurves;
			if (Curves == null) Curves = Figure.ProcessingCurves = new List();
			if (Inverted) { Curves.AddBase(LineItem); } else { Curves.AddLast(LineItem); }
			return LineItem;
		}
		#endregion
		#region #method# AddCurve(MX, MY, EX, EY) 
		public Curve AddCurve(double MX, double MY, double EX, double EY) {
			return AddCurve(new Line(MX, MY, EX, EY));
		}
		#endregion
		#region #method# AddCurve(MX, MY, QX, QY, EX, EY) 
		public Curve AddCurve(double MX, double MY, double QX, double QY, double EX, double EY) {
			return AddCurve(new Quadratic(MX, MY, QX, QY, EX, EY));
		}
		#endregion
		#region #method# DemandFigure 
		public FigureProcessing DemandFigure() {
			var Figure = this.ProcessingFigure;
			if (Figure == null) throw new System.InvalidOperationException();
			return Figure;
		}
		#endregion
		#region #method# AddCurve(MX, MY, cmX, cmY, ceX, ceY, EX, EY) 
		public Curve AddCurve(double MX, double MY, double cmX, double cmY, double ceX, double ceY, double EX, double EY) {
			return AddCurve(new Cubic(MX, MY, cmX, cmY, ceX, ceY, EX, EY));
		}
		#endregion
		#region #method# AddBone(Line) 
		public Curve AddBone(Line Line) {
			var Figure = DemandFigure();
			var Inverted = this.Inverted;
			var LineItem = new Curve(Line.Change(this.Mod, Inverted));
			var Curves = Figure.ProcessingBones;
			if (Curves == null) Curves = Figure.ProcessingBones = new List();
			if (Inverted) { Curves.AddBase(LineItem); } else { Curves.AddLast(LineItem); }
			return LineItem;
		}
		#endregion
		#region #method# AddBone(MX, MY, EX, EY) 
		public Curve AddBone(double MX, double MY, double EX, double EY) {
			return AddBone(new Line(MX, MY, EX, EY));
		}
		#endregion
		#region #method# AddBone(MX, MY, QX, QY, EX, EY) 
		public Curve AddBone(double MX, double MY, double QX, double QY, double EX, double EY) {
			return AddBone(new Quadratic(MX, MY, QX, QY, EX, EY));
		}
		#endregion
		#region #method# AddBone(MX, MY, cmX, cmY, ceX, ceY, EX, EY) 
		public Curve AddBone(double MX, double MY, double cmX, double cmY, double ceX, double ceY, double EX, double EY) {
			return AddBone(new Cubic(MX, MY, cmX, cmY, ceX, ceY, EX, EY));
		}
		#endregion
		#region #method# CutRotate 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void CutRotate() {
			this.Mod = this.Mod?.Next;
		}
		#endregion
		#region #method# AddRotate(AN, CX, CY) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddRotate(double AN, double CX, double CY, Mods Mods = Mods.All) {
			this.Mod = new RotAsMod(this.Mod, AN, CX, CY, Mods);
		}
		#endregion
		#region #method# SetRotate(AN, CX, CY) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void SetRotate(double AN, double CX, double CY) {
			this.Mod = new RotAsMod(this.Mod?.Next, AN, CX, CY);
		}
		#endregion
		#region #method# AddRotate(AX, AY, CX, CY) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddRotate(double AX, double AY, double CX, double CY, bool CW = false, Mods Mods = Mods.All) {
			this.Mod = new RotOfMod(this.Mod, AX, AY, CX, CY, CW, Mods);
		}
		#endregion
		#region #method# AddRotate(CX, CY, BX, BY, AX, AY) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddRotate(double CX, double CY, double BX, double BY, double AX, double AY, Mods Mods = Mods.All) {
			this.Mod = new RotateMod(this.Mod, CX, CY, BX, BY, AX, AY, Mods);
		}
		#endregion
		#region #method# SetRotate(AX, AY, CX, CY) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void SetRotate(double AX, double AY, double CX, double CY, bool CW = false) {
			this.Mod = new RotOfMod(this.Mod?.Next, AX, AY, CX, CY, CW);
		}
		#endregion
		#region #method# CutResize 
		public void CutResize() {
			this.Mod = this.Mod?.Next;
		}
		#endregion
		#region #method# AddResizeMoved(WH, W, H, XY, X, Y) 
		/// <summary>Добавляет изменение размера и смещение координат по указанному размеру)</summary>
		/// <param name="WH">Ширина и высота где единица это текущий размер)</param>
		/// <param name="W">Ширина где единица это текущий размер)</param>
		/// <param name="H">Высота где единица это текущий размер)</param>
		/// <param name="XY">Горизонтальное и вертикальное смещение)</param>
		/// <param name="X">Горизонтальное смещение)</param>
		/// <param name="Y">Вертикальное смещение)</param>
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddResizeMoved(double WH = 1.0, double W = 1.0, double H = 1.0, double XY = 0.0, double X = 0.0, double Y = 0.0) {
			W *= WH;
			H *= WH;
			X += XY;
			Y += XY;
			X *= W;
			Y *= H;
			if (W != 1.0 || H != 1.0 || X != 0.0 || Y != 0.0) {
				this.Mod = new ResizeMod(this.Mod, W, H, X, Y);
			}
		}
		#endregion
		#region #method# SetResizeMoved(WH, W, H, XY, X, Y) 
		/// <summary>Добавляет или устанавливает изменение размера и смещение координат по указанному размеру)</summary>
		/// <param name="WH">Ширина и высота где единица это текущий размер)</param>
		/// <param name="W">Ширина где единица это текущий размер)</param>
		/// <param name="H">Высота где единица это текущий размер)</param>
		/// <param name="XY">Горизонтальное и вертикальное смещение)</param>
		/// <param name="X">Горизонтальное смещение)</param>
		/// <param name="Y">Вертикальное смещение)</param>
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void SetResizeMoved(double WH = 1.0, double W = 1.0, double H = 1.0, double XY = 0.0, double X = 0.0, double Y = 0.0) {
			this.Mod = this.Mod?.Next;
			W *= WH;
			H *= WH;
			X += XY;
			Y += XY;
			X *= W;
			Y *= H;
			if (W != 1.0 || H != 1.0 || X != 0.0 || Y != 0.0) {
				this.Mod = new ResizeMod(this.Mod, W, H, X, Y);
			}
		}
		#endregion
		#region #method# AddResizeMovA(WH, W, H, XY, X, Y) 
		/// <summary>Добавляет изменение размера и смещение координат после изменения размера)</summary>
		/// <param name="WH">Ширина и высота где единица это текущий размер)</param>
		/// <param name="W">Ширина где единица это текущий размер)</param>
		/// <param name="H">Высота где единица это текущий размер)</param>
		/// <param name="XY">Горизонтальное и вертикальное смещение)</param>
		/// <param name="X">Горизонтальное смещение)</param>
		/// <param name="Y">Вертикальное смещение)</param>
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddResizeMovA(double WH = 1.0, double W = 1.0, double H = 1.0, double XY = 0.0, double X = 0.0, double Y = 0.0) {
			W *= WH;
			H *= WH;
			X += XY;
			Y += XY;
			if (W != 1.0 || H != 1.0 || X != 0.0 || Y != 0.0) {
				this.Mod = new ResizeMod(this.Mod, W, H, X, Y);
			}
		}
		#endregion
		#region #method# SetResizeMovA(WH, W, H, XY, X, Y) 
		/// <summary>Добавляет или устанавливает изменение размера и смещение координат после изменения размера)</summary>
		/// <param name="WH">Ширина и высота где единица это текущий размер)</param>
		/// <param name="W">Ширина где единица это текущий размер)</param>
		/// <param name="H">Высота где единица это текущий размер)</param>
		/// <param name="XY">Горизонтальное и вертикальное смещение)</param>
		/// <param name="X">Горизонтальное смещение)</param>
		/// <param name="Y">Вертикальное смещение)</param>
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void SetResizeMovA(double WH = 1.0, double W = 1.0, double H = 1.0, double XY = 0.0, double X = 0.0, double Y = 0.0) {
			this.Mod = this.Mod?.Next;
			W *= WH;
			H *= WH;
			X += XY;
			Y += XY;
			if (W != 1.0 || H != 1.0 || X != 0.0 || Y != 0.0) {
				this.Mod = new ResizeMod(this.Mod, W, H, X, Y);
			}
		}
		#endregion
		#region #class# ResizeMod 
		public class ResizeMod : Change {
			public double SX, SY, MX, MY;
			public ResizeMod(Change Next, double SX, double SY, double MX, double MY, Mods Mods = Mods.All) : base(Next, Mods) {
				this.SX = SX;
				this.SY = SY;
				this.MX = MX;
				this.MY = MY;
			}
			public override void Modify(ref double X, ref double Y, bool x, bool y) {
				if (x || y) {
					var RX = X;
					var RY = Y;
					if (x) X = RX * SX + MX;
					if (y) Y = RY * SY + MY;
				}
			}
		}
		#endregion
		#region #class# Change 
		public abstract class Change {
			public readonly Change Next;
			public readonly Mods Mods;
			public Change(Change Next, Mods Mods) {
				this.Next = Next;
				this.Mods = Mods;
			}
			public abstract void Modify(ref double X, ref double Y, bool x, bool y);
		}
		#endregion
		#region #enum# Mods 
		[System.Flags]
		public enum Mods {
			MX = 1,
			MY = 2,
			Mxy = MX | MY,
			EX = 4,
			EY = 8,
			Exy = EX | EY,
			QX = 16,
			QY = 32,
			Qxy = QX | QY,
			cmX = 64,
			cmY = 128,
			cmxy = cmX | cmY,
			ceX = 256,
			ceY = 512,
			cexy = ceX | ceY,
			CX = cmX | ceX,
			CY = cmY | ceY,
			Cxy = cmxy | cexy,
			All = Mxy | Exy | Qxy | Cxy
		}
		#endregion
		#region #class# RotAsMod 
		public class RotateMod : Change {
			public double AR, CX, CY;
			public RotateMod(Change Next, double CX, double CY, double AR, Mods Mods = Mods.All) : base(Next, Mods) {
				this.AR = AR;
				this.CX = CX;
				this.CY = CY;
			}
			public RotateMod(Change Next, double CX, double CY, double BX, double BY, double AX, double AY, Mods Mods = Mods.All) : base(Next, Mods) {
				this.AR = AR = GetaR1(CX, CY, BX, BY, AX, AY);
				this.CX = CX;
				this.CY = CY;
			}
			public override void Modify(ref double X, ref double Y, bool x, bool y) {
				if (x || y) {
					var AX = X;
					var AY = Y;
					Rotate1(this.CX, this.CY, ref AX, ref AY, this.AR);
					if (x) X = AX;
					if (y) Y = AY;
				}
			}
		}
		public class RotAsMod : Change {
			public double A, CX, CY;
			public RotAsMod(Change Next, double A, double CX, double CY, Mods Mods = Mods.All) : base(Next, Mods) {
				this.A = A / 360;
				this.CX = CX;
				this.CY = CY;
			}
			public override void Modify(ref double X, ref double Y, bool x, bool y) {
				if (x || y) {
					var RX = X;
					var RY = Y;
					Rotate1(this.CX, this.CY, ref RX, ref RY, this.A);
					if (x) X = RX;
					if (y) Y = RY;
				}
			}
		}
		#endregion
		#region #class# RotOfMod 
		public class RotOfMod : Change {
			public readonly double AR;
			public readonly double AX, AY, CX, CY;
			public readonly bool CW;
			public RotOfMod(Change Next, double AX, double AY, double CX, double CY, bool CW, Mods Mods = Mods.All) : base(Next, Mods) {
				this.AX = AX;
				this.AY = AY;
				this.CX = CX;
				this.CY = CY;
				this.CW = CW;
			}
			public override void Modify(ref double X, ref double Y, bool x, bool y) {
				if (x || y) {
					var A = GetaR1(CX, CY, AX, AY, AX, AY);
					if (CW) A = -A;
					var RX = X;
					var RY = Y;
					Rotate1(this.CX, this.CY, ref RX, ref RY, A);
					if (x) X = RX;
					if (y) Y = RY;
				}
			}
		}
		#endregion
		#region #class# Figure 
		public class Figure : Item {
			public bool IsFilled;
			public bool IsClozed;
			public List Curves;
			public List Bones;
			#region #new# (IsFilled, IsClozed) 
			public Figure(bool IsFilled, bool IsClozed) {
				this.IsFilled = IsFilled;
				this.IsClozed = IsClozed;
			}
			#endregion
			#region #method# ToString 
			public override string ToString() {
				var I = System.Globalization.CultureInfo.InvariantCulture;
				var S = "Figure";
				var Curves = this.Curves;
				if (Curves != null) { S += " Curves = " + Curves.Count.ToString(I); }
				var Bones = this.Bones;
				if (Bones != null) { S += " Bones = " + Bones.Count.ToString(I); }
				if (IsFilled) S += " IsFilled";
				if (IsClozed) S += " IsClozed";
				return S;
			}
			#endregion
		}
		#endregion
		#region #class# FigureProcessing 
		public class FigureProcessing : Figure {
			public List ProcessingCurves;
			public List ProcessingBones;
			#region #new# (IsFilled, IsClozed) 
			public FigureProcessing(bool IsFilled, bool IsClozed) : base(IsFilled, IsClozed) {
			}
			#endregion
			#region #method# ToString 
			public override string ToString() {
				var I = System.Globalization.CultureInfo.InvariantCulture;
				var S = base.ToString();
				var ProcessingCurves = this.ProcessingCurves;
				if (ProcessingCurves != null) { S += " ProcessingCurves = " + ProcessingCurves.Count.ToString(I); }
				var ProcessingBones = this.ProcessingBones;
				if (ProcessingBones != null) { S += " ProcessingBones = " + ProcessingBones.Count.ToString(I); }
				return S;
			}
			#endregion
			#region #method# End 
			public void End() {
				var Bones = this.Bones;
				var ProcessingBones = this.ProcessingBones;
				if (ProcessingBones != null && ProcessingBones.Count > 0) {
					if (Bones != null) {
						Bones.AddLast(ProcessingBones);
					} else {
						this.Bones = ProcessingBones;
					}
					this.ProcessingBones = null;
				}
				var Curves = this.Curves;
				var ProcessingCurves = this.ProcessingCurves;
				if (ProcessingCurves != null && ProcessingCurves.Count > 0) {
					if (Curves != null) {
						Curves.AddLast(ProcessingCurves);
					} else {
						this.Curves = ProcessingCurves;
					}
					this.ProcessingCurves = null;
				}
			}
			#endregion
		}
		#endregion
		#region #class# Line 
		public class Line {
			public double MX;
			public double MY;
			public double EX;
			public double EY;
			#region #new# 
			public Line() { }
			#endregion
			#region #new# (MX, MY, EX, EY) 
			public Line(double MX, double MY, double EX, double EY) {
				this.MX = MX; this.MY = MY; this.EX = EX; this.EY = EY;
			}
			#endregion
			#region #method# Invert 
			public virtual void Invert() {
				var V = this.EX;
				this.EX = this.MX;
				this.MX = V;
				V = this.EY;
				this.EY = this.MY;
				this.MY = V;
			}
			#endregion
			#region #method# Change(Mod, Inverted) 
			public virtual Line Change(Change Mod, bool Inverted) {
				var MX = this.MX; var MY = this.MY; var EX = this.EX; var EY = this.EY;
				while (Mod != null) {
					Mod.Modify(ref MX, ref MY, (Mod.Mods & Mods.MX) != 0, (Mod.Mods & Mods.MY) != 0);
					Mod.Modify(ref EX, ref EY, (Mod.Mods & Mods.EX) != 0, (Mod.Mods & Mods.EY) != 0);
					Mod = Mod.Next;
				}
				if (Inverted)
					return new Line(EX, EY, MX, MY);
				return new Line(MX, MY, EX, EY);
			}
			#endregion
			#region #method# If(Context, X, Y) 
			public virtual void If(System.Windows.Media.StreamGeometryContext Context, double X, double Y) {
				if (!double.Equals(X, MX) || !double.Equals(Y, MY)) {
					if (Sqrt(X - MX, Y - MY) > 10.0) {

					}
					Context.LineTo(new System.Windows.Point(MX, MY), true, true);
				}
			}
			#endregion
			#region #method# To(Context) 
			public virtual void To(System.Windows.Media.StreamGeometryContext Context) {
				Context.LineTo(new System.Windows.Point(EX, EY), true, true);
			}
			#endregion
			#region #method# ToPathString 
			public virtual string ToPathString() {
				var I = System.Globalization.CultureInfo.InvariantCulture;
				return "L" + EX.ToString(I) + "," + EY.ToString(I);
			}
			#endregion
			#region #method# ToCompessedString(Prev) 
			public virtual string ToCompessedString(Line Prev) {
				var S = "";
				var I = System.Globalization.CultureInfo.InvariantCulture;
				if (this.Prefix == 'L') {
					if (Prev == null) { S = "M" + MX.ToString(I) + "," + MY.ToString(I); }
					if (MX == EX) {
						var V = "V" + EY.ToString(I);
						var v = "v" + (EY - MY).ToString(I);
						if (v.Length < V.Length) { S += v; } else { S += V; }
					} else if (MY == EY) {
						var H = "H" + EX.ToString(I);
						var h = "h" + (EX - MX).ToString(I);
						if (h.Length < H.Length) { S += h; } else { S += H; }
					} else {
						var L = "L" + EX.ToString(I) + "," + EY.ToString(I);
						var l = "l" + (EX - MX).ToString(I) + "," + (EY - MY).ToString(I);
						if (l.Length < L.Length) { S += l; } else { S += L; }
					}
				}
				return S;
			}
			#endregion
			#region #method# ToString 
			public override string ToString() {
				var I = System.Globalization.CultureInfo.InvariantCulture;
				return "M" + MX.ToString(I) + "," + MY.ToString(I) + "L" + EX.ToString(I) + "," + EY.ToString(I);
			}
			#endregion
			#region #method# ToArcC(Acw) 
			public Cubic ToArcC(bool Acw = false) {
				var MX = this.MX;
				var MY = this.MY;
				var EX = this.EX;
				var EY = this.EY;
				var cmX = MX;
				var cmY = MY;
				var ceX = EX;
				var ceY = EY;
				if (((MX < EX && MY < EY) || (MX > EX && MY > EY)) ^ Acw) {
					cmX += ((EX - MX) * Arc14);
					ceY += ((MY - EY) * Arc14);
				} else {
					cmY += ((EY - MY) * Arc14);
					ceX += ((MX - EX) * Arc14);
				}
				return new Cubic(MX, MY, cmX, cmY, ceX, ceY, EX, EY);
			}
			#endregion
			#region #method# Cuted(r0) 
			public Line Cuted(double r0) {
				if ((r0 < 1.0) && (r0 > -1.0)) {
					if (r0 != 0.0) {
						var root = r0 < 0.0 ? 1.0 + r0 : r0;
						var x00 = this.MX;
						var y00 = this.MY;
						var x11 = this.EX;
						var y11 = this.EY;
						var x01 = (x11 - x00) * root + x00;
						var y01 = (y11 - y00) * root + y00;
						if (r0 < 0.0) {
							this.MX = x00; this.MY = y00;
							this.EX = x01; this.EY = y01;
						} else {
							this.MX = x01; this.MY = y01;
							this.EX = x11; this.EY = y11;
						}
					}
				}
				return this;
			}
			#endregion
			#region #method# Cuted(r0, r1) 
			public Line Cuted(double r0, double r1) {
				if ((r0 < 1.0) && (r0 > -1.0)) {
					r1 = (r1 / (1.0 - r0));
					while (r0 != 0.0) {
						var root = r0 < 0.0 ? 1.0 + r0 : r0;
						var x00 = this.MX;
						var y00 = this.MY;
						var x11 = this.EX;
						var y11 = this.EY;
						var x01 = (x11 - x00) * root + x00;
						var y01 = (y11 - y00) * root + y00;
						if (r0 < 0.0) {
							this.MX = x00; this.MY = y00;
							this.EX = x01; this.EY = y01;
						} else {
							this.MX = x01; this.MY = y01;
							this.EX = x11; this.EY = y11;
						}
						r0 = r1; r1 = 0.0;
					}
				}
				return this;
			}
			#endregion
			#region #method# Cuted(M, E) 
			public virtual Line Cuted(Preset M, Preset E) {
				if (M == null && E == null) return this;
				if (M != null && E != null) {
					Cuted(M.Value, -E.Value);
				} else {
					if (M != null) {
						Cuted(M.Value);
					} else if (E != null) {
						Cuted(-E.Value);
					}
				}
				return this;
			}
			#endregion
			public virtual char Prefix => 'L';
			#region #method# Inverted 
			public Line Inverted() {
				var V = this.EX;
				this.EX = this.MX;
				this.MX = V;
				V = this.EY;
				this.EY = this.MY;
				this.MY = V;
				return this;
			}
			#endregion
			#region #method# HalfArcM(Size) 
			public virtual List HalfArcM(double Size) {
				var List = new List();
				var SA = Size;
				var SB = -SA;
				var A = SA * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var EX = this.EX;
				var EY = this.EY;
				var l0 = RootOffset(EX - MX, EY - MY, out var l0X, out var l0Y);
				if (l0 == 0.0) {
					EX = MX + SA;
					EY = MY;
				}
				var aX = MX + SA * l0X;
				var aY = MY + SA * l0Y;
				var bX = aX;
				var bY = aY;
				var cX = MX + SB * l0X;
				var cY = MY + SB * l0Y;
				var baX = MX;
				var baY = MY;
				var cbX = MX;
				var cbY = MY;
				Rotate1(MX, MY, ref bX, ref bY, 0.25);
				Rotate1(bX, bY, ref baX, ref baY, 0.25);
				Rotate1(bX, bY, ref cbX, ref cbY, 0.75);
				List.AddLast(new Curve(new Cubic(cX, cY, cbX, cbY, bX, bY)));
				List.AddLast(new Curve(new Cubic(bX, bY, baX, baY, aX, aY)));
				return List;
			}
			#endregion
			#region #method# HalfArcE(Size) 
			public virtual List HalfArcE(double Size) {
				var List = new List();
				var SA = Size;
				var SB = -SA;
				var A = SA * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var EX = this.EX;
				var EY = this.EY;
				var l0 = RootOffset(EX - MX, EY - MY, out var l0X, out var l0Y);
				if (l0 == 0.0) {
					MX = MX + SB;
					MY = EY;
				}
				var aX = EX + SA * l0X;
				var aY = EY + SA * l0Y;
				var bX = aX;
				var bY = aY;
				var cX = EX + SB * l0X;
				var cY = EY + SB * l0Y;
				var abX = EX;
				var abY = EY;
				var bcX = EX;
				var bcY = EY;
				Rotate1(EX, EY, ref bX, ref bY, -0.25);
				Rotate1(bX, bY, ref abX, ref abY, -0.25);
				Rotate1(bX, bY, ref bcX, ref bcY, -0.75);
				List.AddLast(new Curve(new Cubic(aX, aY, abX, abY, bX, bY)));
				List.AddLast(new Curve(new Cubic(bX, bY, bcX, bcY, cX, cY)));
				return List;
			}
			#endregion
			#region #method# Div(root, A, B) 
			public virtual void Div(double root, out Line A, out Line B) {
				var x00 = MX;
				var y00 = MY;
				var x11 = EX;
				var y11 = EY;
				var x01 = (x11 - x00) * root + x00;
				var y01 = (y11 - y00) * root + y00;
				A = new Line(x00, y00, x01, y01);
				B = new Line(x01, y01, x11, y11);
			}
			#endregion
			#region #method# DivA(root) 
			public virtual Line DivA(double root) {
				var x00 = MX;
				var y00 = MY;
				var x11 = EX;
				var y11 = EY;
				var x01 = (x11 - x00) * root + x00;
				var y01 = (y11 - y00) * root + y00;
				return new Line(x00, y00, x01, y01);
			}
			#endregion
			#region #method# DivB(root) 
			public virtual Line DivB(double root) {
				var x00 = MX;
				var y00 = MY;
				var x11 = EX;
				var y11 = EY;
				var x01 = (x11 - x00) * root + x00;
				var y01 = (y11 - y00) * root + y00;
				return new Line(x01, y01, x11, y11);
			}
			#endregion
			#region #method# DivC(root, X, Y) 
			public virtual void DivC(double root, out double X, out double Y) {
				var x00 = MX;
				var y00 = MY;
				var x11 = EX;
				var y11 = EY;
				X = (x11 - x00) * root + x00;
				Y = (y11 - y00) * root + y00;
			}
			#endregion
			#region #method# RootsList(Roots) 
			public List RootsList(double[] Roots = null) {
				List List = new List();
				Line A = this;
				var R = 0.0;
				if (Roots != null) {
					var L = Roots.Length;
					if (L > 0) {
						var I = 0;
						while (I < L) {
							var r = Roots[I];
							A.Div((r - R) / (1.0 - R), out var B, out A);
							List.AddLast(new CurveRoot(B, R, r - R));
							R = r;
							I++;
						}
					}
				}
				List.AddLast(new CurveRoot(A, R, 1.0 - R));
				return List;
			}
			#endregion
			#region #method# Ext(S, A, B) 
			/// <summary>Расширяет кривую на указанную толщину)</summary>
			/// <param name="S">Толщина линии, положительное или отридцательное значение определяет сторону)</param>
			/// <param name="A">Возвращаемая кривая, если длина исходной кривой больше нуля)</param>
			/// <param name="B">Инвертированная кривая с другой стороны, если длина исходной кривой больше нуля)</param>
			/// <returns>Успех если длина исходной кривой больше нуля)</returns>
			public virtual bool Ext(double S, out Line A, out Line B) {
				var MX = this.MX;
				var MY = this.MY;
				var EX = this.EX;
				var EY = this.EY;
				var cX = EX - MX;
				var cY = EY - MY;
				var l = Sqrt(cX, cY);
				if (l == 0) { A = null; B = null; return false; }
				var lX = -cY / l;
				var lY = cX / l;

				var aMX = MX + S * lX;
				var aMY = MY + S * lY;
				var aEX = EX + S * lX;
				var aEY = EY + S * lY;
				S = -S;
				var bMX = EX + S * lX;
				var bMY = EY + S * lY;
				var bEX = MX + S * lX;
				var bEY = MY + S * lY;
				A = new Line(aMX, aMY, aEX, aEY);
				B = new Line(bMX, bMY, bEX, bEY);
				return true;
			}
			#endregion
			#region #method# Ext(S, R, I) 
			/// <summary>Расширяет кривую на указанную толщину)</summary>
			/// <param name="S">Толщина линии, положительное или отридцательное значение определяет сторону)</param>
			/// <param name="R">Возвращаемая кривая, если длина исходной кривой больше нуля)</param>
			/// <param name="I">Истина инвертирует значение толщины и направление возвращаемой кривой)</param>
			/// <returns>Успех если длина исходной кривой больше нуля)</returns>
			public virtual bool Ext(double S, out Line R, bool I = false) {
				var MX = this.MX;
				var MY = this.MY;
				var EX = this.EX;
				var EY = this.EY;
				var l0 = RootOffset(EX - MX, EY - MY, out var l0X, out var l0Y);
				if (!I) {
					R = new Line(
						MX + S * l0X,
						MY + S * l0Y,
						EX + S * l0X,
						EY + S * l0Y);
				} else {
					S = -S;
					R = new Line(
						EX + S * l0X,
						EY + S * l0Y,
						MX + S * l0X,
						MY + S * l0Y);
				}
				return true;
			}
			#endregion
			#region #method# ExtCw(Size, exA, exB, cwA, cwB) 
			public virtual bool ExtCw(double Size, ref Line exA, ref Line exB, ref bool cwA, ref bool cwB) {
				if (this.Ext(Size, out var A, out var B)) {
					exA = A;
					exB = B;
					cwA = (GetaR1(this.MX, this.MY, A.MX, A.MY, A.EX, A.EY) > 0.5);
					cwB = (GetaR1(this.MX, this.MY, B.MX, B.MY, B.EX, B.EY) > 0.5);
					return true;
				}
				return false;
			}
			#endregion
			#region #method# ExtCw(Size, Roots) 
			public List ExtCw(double Size, List Roots = null) {
				List List = new List();
				var DIV = 0.5;
				var POS = 0.0;
				var ROOT = 0.0;
				Line RES = this;
				Line TES = this;
				var LastRoot = 0.0;
				var LastSize = 1.0;
				CurveRoot Item = null;
				if (Roots != null) {
					Item = Roots.Base as CurveRoot;
					if (Item != null) {
						TES = RES = Item.Line;
						LastRoot = Item.Root;
						LastSize = Item.Size;
						Item = Item.Next as CurveRoot;
					}
				}
				Stab Stab = null;//new Stab(LastRoot, LastSize) { ResetA = true, ResetB = true };
												 //List.AddLast(Stab);
				var cwA = false;
				var cwB = false;
				var prevA = true;
				var prevB = true;
				Line NOW;
				Line RAM;
				Line PreA = null;
				Line PreB = null;
				RTES:
				if (TES.ExtCw(Size, ref PreA, ref PreB, ref cwA, ref cwB)) {
					if (Stab == null) {
						Stab = new Stab(LastRoot, LastSize) { ResetA = cwA, ResetB = cwB };
						List.AddLast(Stab);
						prevA = cwA; prevB = cwB;
					} else if ((prevA != cwA || prevB != cwB) && Stab.IsUsed) {
						Stab = Stab.AddLastTo(List, cwA, cwB, ROOT, out LastRoot, out LastSize);
						ROOT = 0.0;
					}
					prevA = cwA; prevB = cwB;
					Stab.Add(PreA, PreB, TES, LastRoot + (ROOT * LastSize), LastSize - (ROOT * LastSize));
					POS = 0.0;
				} else {
					NEXT:
					TES.Div(DIV, out NOW, out RAM);
					if (NOW.ExtCw(Size, ref PreA, ref PreB, ref cwA, ref cwB)) {
						var PDIV = ((1.0 - POS) * DIV);
						var RPDIV = ((1.0 - ROOT) * PDIV);
						if (Stab == null) {
							Stab = new Stab(LastRoot, LastSize) { ResetA = cwA, ResetB = cwB };
							List.AddLast(Stab);
							prevA = cwA; prevB = cwB;
						} else if ((prevA != cwA || prevB != cwB) && Stab.IsUsed) {
							Stab = Stab.AddLastTo(List, cwA, cwB, ROOT, out LastRoot, out LastSize);
							ROOT = 0.0;
						}
						Stab.Add(PreA, PreB, NOW, LastRoot + (ROOT * LastSize), RPDIV * LastSize);
						POS += PDIV;
						ROOT += RPDIV;
						DIV = 0.5;
						if ((prevA != cwA || prevB != cwB)) {
							prevA = cwA; prevB = cwB;
							RES.Div(POS, out var CUT, out RES);
							TES = RES;
							POS = 0.0;
							goto RTES;
						} else {
							TES = RAM;
						}
						goto RTES;
					} else { DIV /= 2.0; if (DIV > 0.0) goto NEXT; }
				}
				if (Item != null) {
					LastRoot = Item.Root;
					LastSize = Item.Size;
					//List.AddLast(Stab = new Stab(Item.Root, Item.Size));
					Stab = null;
					ROOT = 0.0;
					POS = 0.0;
					TES = RES = Item.Line;
					Item = Item.Next as CurveRoot;
					goto RTES;
				}
				return List;
			}
			#endregion
		}
		#endregion
		#region #class# Cubic 
		public class Cubic : Line {
			#region #new# 
			public Cubic() { }
			#endregion
			#region #new# (MX, MY, cmX, cmY, ceX, ceY, EX, EY) 
			public Cubic(double MX, double MY, double cmX, double cmY, double ceX, double ceY, double EX, double EY) {
				this.MX = MX; this.MY = MY; this.cmX = cmX; this.cmY = cmY; this.ceX = ceX; this.ceY = ceY; this.EX = EX; this.EY = EY;
			}
			#endregion
			#region #new# (MX, MY, AX, AY, EX, EY) 
			public Cubic(double MX, double MY, double AX, double AY, double EX, double EY) {
				this.MX = MX; this.MY = MY; this.cmX = AX; this.cmY = AY; this.ceX = AX; this.ceY = AY; this.EX = EX; this.EY = EY;
				SetMulLen(MX, MY, ref this.cmX, ref this.cmY, Arc14);
				SetMulLen(EX, EY, ref this.ceX, ref this.ceY, Arc14);
			}
			#endregion
			public double cmX;
			public double cmY;
			public double ceX;
			public double ceY;
			#region #method# Invert 
			public override void Invert() {
				var V = this.EX;
				this.EX = this.MX;
				this.MX = V;
				V = this.EY;
				this.EY = this.MY;
				this.MY = V;
				V = this.ceX;
				this.ceX = this.cmX;
				this.cmX = V;
				V = this.ceY;
				this.ceY = this.cmY;
				this.cmY = V;
			}
			#endregion
			#region #method# Div(R, A, B) 
			public override void Div(double R, out Line A, out Line B) {
				var x00 = MX;
				var y00 = MY;
				var x11 = cmX;
				var y11 = cmY;
				var x22 = ceX;
				var y22 = ceY;
				var x33 = EX;
				var y33 = EY;
				var x01 = (x11 - x00) * R + x00;
				var y01 = (y11 - y00) * R + y00;

				var x12 = (x22 - x11) * R + x11;
				var y12 = (y22 - y11) * R + y11;

				var x23 = (x33 - x22) * R + x22;
				var y23 = (y33 - y22) * R + y22;

				var x02 = (x12 - x01) * R + x01;
				var y02 = (y12 - y01) * R + y01;

				var x13 = (x23 - x12) * R + x12;
				var y13 = (y23 - y12) * R + y12;

				var x03 = (x13 - x02) * R + x02;
				var y03 = (y13 - y02) * R + y02;
				A = new Cubic(x00, y00, x01, y01, x02, y02, x03, y03);
				B = new Cubic(x03, y03, x13, y13, x23, y23, x33, y33);
			}
			#endregion
			#region #method# DivA(R) 
			public override Line DivA(double R) {
				var x00 = MX;
				var y00 = MY;
				var x11 = cmX;
				var y11 = cmY;
				var x22 = ceX;
				var y22 = ceY;
				var x33 = EX;
				var y33 = EY;
				var x01 = (x11 - x00) * R + x00;
				var y01 = (y11 - y00) * R + y00;
				var x12 = (x22 - x11) * R + x11;
				var y12 = (y22 - y11) * R + y11;
				var x23 = (x33 - x22) * R + x22;
				var y23 = (y33 - y22) * R + y22;
				var x02 = (x12 - x01) * R + x01;
				var y02 = (y12 - y01) * R + y01;
				var x13 = (x23 - x12) * R + x12;
				var y13 = (y23 - y12) * R + y12;
				var x03 = (x13 - x02) * R + x02;
				var y03 = (y13 - y02) * R + y02;
				return new Cubic(x00, y00, x01, y01, x02, y02, x03, y03);
			}
			#endregion
			#region #method# DivB(R) 
			public override Line DivB(double R) {
				var x00 = MX;
				var y00 = MY;
				var x11 = cmX;
				var y11 = cmY;
				var x22 = ceX;
				var y22 = ceY;
				var x33 = EX;
				var y33 = EY;
				var x01 = (x11 - x00) * R + x00;
				var y01 = (y11 - y00) * R + y00;
				var x12 = (x22 - x11) * R + x11;
				var y12 = (y22 - y11) * R + y11;
				var x23 = (x33 - x22) * R + x22;
				var y23 = (y33 - y22) * R + y22;
				var x02 = (x12 - x01) * R + x01;
				var y02 = (y12 - y01) * R + y01;
				var x13 = (x23 - x12) * R + x12;
				var y13 = (y23 - y12) * R + y12;
				var x03 = (x13 - x02) * R + x02;
				var y03 = (y13 - y02) * R + y02;
				return new Cubic(x03, y03, x13, y13, x23, y23, x33, y33);
			}
			#endregion
			#region #method# DivC(R, X, Y) 
			public override void DivC(double R, out double X, out double Y) {
				var x00 = MX;
				var y00 = MY;
				var x11 = cmX;
				var y11 = cmY;
				var x22 = ceX;
				var y22 = ceY;
				var x33 = EX;
				var y33 = EY;
				var x01 = (x11 - x00) * R + x00;
				var y01 = (y11 - y00) * R + y00;
				var x12 = (x22 - x11) * R + x11;
				var y12 = (y22 - y11) * R + y11;
				var x23 = (x33 - x22) * R + x22;
				var y23 = (y33 - y22) * R + y22;
				var x02 = (x12 - x01) * R + x01;
				var y02 = (y12 - y01) * R + y01;
				var x13 = (x23 - x12) * R + x12;
				var y13 = (y23 - y12) * R + y12;
				var x03 = (x13 - x02) * R + x02;
				var y03 = (y13 - y02) * R + y02;
				X = x03;
				Y = y03;
			}
			#endregion
			#region #method# FixM 
			public double FixM() {
				var C = 0;
				var R = 0.0;
				var r = 0.5;
				var rr = 0.5;
				End:
				var x00 = MX;
				var y00 = MY;
				var x11 = cmX;
				var y11 = cmY;
				var x22 = ceX;
				var y22 = ceY;
				var x33 = EX;
				var y33 = EY;
				Next:
				var x01 = (x11 - x00) * rr + x00;
				var y01 = (y11 - y00) * rr + y00;
				var x12 = (x22 - x11) * rr + x11;
				var y12 = (y22 - y11) * rr + y11;
				var x23 = (x33 - x22) * rr + x22;
				var y23 = (y33 - y22) * rr + y22;
				var x02 = (x12 - x01) * rr + x01;
				var y02 = (y12 - y01) * rr + y01;
				var x13 = (x23 - x12) * rr + x12;
				var y13 = (y23 - y12) * rr + y12;
				var x03 = (x13 - x02) * rr + x02;
				var y03 = (y13 - y02) * rr + y02;
				if (r > 0.0) {
					if (x00 != x03 && y00 != y03) {
						x11 = x01; y11 = y01; x22 = x02; y22 = y02; x33 = x03; y33 = y03;
					} else {
						if (x00 == x03 && y00 == y03 && x11 == x13 && y11 == y13 && x22 == x23 && y22 == y23) { r = 0.0; } else {
							x00 = x03; y00 = y03; x11 = x13; y11 = y13; x22 = x23; y22 = y23;
							R += r;
						}
					}
					C++;
					r *= 0.5;
					goto Next;
				} else {
					if (rr != R) { rr = R; goto End; }
					MX = x03; MY = y03; cmX = x13; cmY = y13; ceX = x23; ceY = y23;
				}
				return R;
			}
			#endregion
			#region #method# FixE 
			public double FixE() {
				var C = 0;
				var R = 1.0;
				var r = 0.5;
				var rr = 0.5;
				End:
				var x00 = MX;
				var y00 = MY;
				var x11 = cmX;
				var y11 = cmY;
				var x22 = ceX;
				var y22 = ceY;
				var x33 = EX;
				var y33 = EY;
				Next:
				var x01 = (x11 - x00) * rr + x00;
				var y01 = (y11 - y00) * rr + y00;
				var x12 = (x22 - x11) * rr + x11;
				var y12 = (y22 - y11) * rr + y11;
				var x23 = (x33 - x22) * rr + x22;
				var y23 = (y33 - y22) * rr + y22;
				var x02 = (x12 - x01) * rr + x01;
				var y02 = (y12 - y01) * rr + y01;
				var x13 = (x23 - x12) * rr + x12;
				var y13 = (y23 - y12) * rr + y12;
				var x03 = (x13 - x02) * rr + x02;
				var y03 = (y13 - y02) * rr + y02;
				if (r > 0.0) {
					if (x11 != x03 && y11 != y03) {
						x00 = x03; y00 = y03; x11 = x13; y11 = y13; x22 = x23; y22 = y23;
					} else {
						if (x11 == x01 && y11 == y01 && x22 == x02 && y22 == y02 && x33 == x03 && y33 == y03) { r = 0.0; } else {
							x11 = x01; y11 = y01; x22 = x02; y22 = y02; x33 = x03; y33 = y03;
							R -= r;
						}
					}
					C++;
					r *= 0.5;
					goto Next;
				} else {
					if (rr != R) { rr = R; goto End; }
					cmX = x01; cmY = y01; ceX = x02; ceY = y02; EX = x03; EY = y03;
				}
				return R;
			}
			#endregion
			#region #method# Change(Mod, Inverted) 
			public override Line Change(Change Mod, bool Inverted) {
				var MX = this.MX; var MY = this.MY; var cmX = this.cmX; var cmY = this.cmY; var ceX = this.ceX; var ceY = this.ceY; var EX = this.EX; var EY = this.EY;
				while (Mod != null) {
					Mod.Modify(ref MX, ref MY, (Mod.Mods & Mods.MX) != 0, (Mod.Mods & Mods.MY) != 0);
					Mod.Modify(ref EX, ref EY, (Mod.Mods & Mods.EX) != 0, (Mod.Mods & Mods.EY) != 0);
					Mod.Modify(ref cmX, ref cmY, (Mod.Mods & Mods.cmX) != 0, (Mod.Mods & Mods.cmY) != 0);
					Mod.Modify(ref ceX, ref ceY, (Mod.Mods & Mods.ceX) != 0, (Mod.Mods & Mods.ceY) != 0);
					Mod = Mod.Next;
				}
				if (Inverted)
					return new Cubic(EX, EY, ceX, ceY, cmX, cmY, MX, MY);
				return new Cubic(MX, MY, cmX, cmY, ceX, ceY, EX, EY);
			}
			#endregion
			#region #method# To(Context) 
			public override void To(System.Windows.Media.StreamGeometryContext Context) {
				Context.BezierTo(new System.Windows.Point(cmX, cmY), new System.Windows.Point(ceX, ceY), new System.Windows.Point(EX, EY), true, true);
			}
			#endregion
			#region #method# ToPathString 
			public override string ToPathString() {
				var I = System.Globalization.CultureInfo.InvariantCulture;
				return "C" + cmX.ToString(I) + "," + cmY.ToString(I) + " " + ceX.ToString(I) + "," + ceY.ToString(I) + " " + EX.ToString(I) + "," + EY.ToString(I);
			}
			#endregion
			#region #method# ToCompessedString(Prev) 
			public override string ToCompessedString(Line Prev) {
				var I = System.Globalization.CultureInfo.InvariantCulture;
				return "C" + cmX.ToString(I) + "," + cmY.ToString(I) + " " + ceX.ToString(I) + "," + ceY.ToString(I) + " " + EX.ToString(I) + "," + EY.ToString(I);
			}
			#endregion
			#region #method# ToString 
			public override string ToString() {
				var I = System.Globalization.CultureInfo.InvariantCulture;
				return "M" + MX.ToString(I) + "," + MY.ToString(I) + "C" + cmX.ToString(I) + "," + cmY.ToString(I) + " " + ceX.ToString(I) + "," + ceY.ToString(I) + " " + EX.ToString(I) + "," + EY.ToString(I);
			}
			#endregion
			#region #method# Cuted(r0) 
			public Cubic Cuted(double r0) {
				if ((r0 < 1.0) && (r0 > -1.0)) {
					if (r0 != 0.0) {
						var root = r0 < 0.0 ? 1.0 + r0 : r0;
						var x00 = this.MX;
						var y00 = this.MY;
						var x11 = this.cmX;
						var y11 = this.cmY;
						var x22 = this.ceX;
						var y22 = this.ceY;
						var x33 = this.EX;
						var y33 = this.EY;
						var x01 = (x11 - x00) * root + x00;
						var y01 = (y11 - y00) * root + y00;
						var x12 = (x22 - x11) * root + x11;
						var y12 = (y22 - y11) * root + y11;
						var x23 = (x33 - x22) * root + x22;
						var y23 = (y33 - y22) * root + y22;
						var x02 = (x12 - x01) * root + x01;
						var y02 = (y12 - y01) * root + y01;
						var x13 = (x23 - x12) * root + x12;
						var y13 = (y23 - y12) * root + y12;
						var x03 = (x13 - x02) * root + x02;
						var y03 = (y13 - y02) * root + y02;
						if (r0 < 0.0) {
							this.MX = x00; this.MY = y00;
							this.cmX = x01; this.cmY = y01;
							this.ceX = x02; this.ceY = y02;
							this.EX = x03; this.EY = y03;
						} else {
							this.MX = x03; this.MY = y03;
							this.cmX = x13; this.cmY = y13;
							this.ceX = x23; this.ceY = y23;
							this.EX = x33; this.EY = y33;
						}
					}
				}
				return this;
			}
			#endregion
			#region #method# Cuted(r0, r1) 
			public Cubic Cuted(double r0, double r1) {
				if ((r0 < 1.0) && (r0 > -1.0)) {
					r1 = (r1 / (1.0 - r0));
					while (r0 != 0.0) {
						var root = r0 < 0.0 ? 1.0 + r0 : r0;
						var x00 = this.MX;
						var y00 = this.MY;
						var x11 = this.cmX;
						var y11 = this.cmY;
						var x22 = this.ceX;
						var y22 = this.ceY;
						var x33 = this.EX;
						var y33 = this.EY;
						var x01 = (x11 - x00) * root + x00;
						var y01 = (y11 - y00) * root + y00;
						var x12 = (x22 - x11) * root + x11;
						var y12 = (y22 - y11) * root + y11;
						var x23 = (x33 - x22) * root + x22;
						var y23 = (y33 - y22) * root + y22;
						var x02 = (x12 - x01) * root + x01;
						var y02 = (y12 - y01) * root + y01;
						var x13 = (x23 - x12) * root + x12;
						var y13 = (y23 - y12) * root + y12;
						var x03 = (x13 - x02) * root + x02;
						var y03 = (y13 - y02) * root + y02;
						if (r0 < 0.0) {
							this.MX = x00; this.MY = y00;
							this.cmX = x01; this.cmY = y01;
							this.ceX = x02; this.ceY = y02;
							this.EX = x03; this.EY = y03;
						} else {
							this.MX = x03; this.MY = y03;
							this.cmX = x13; this.cmY = y13;
							this.ceX = x23; this.ceY = y23;
							this.EX = x33; this.EY = y33;
						}
						r0 = r1; r1 = 0.0;
					}
				}
				return this;
			}
			#endregion
			#region #method# Cuted(M, E) 
			public override Line Cuted(Preset M, Preset E) {
				if (M == null && E == null) return this;
				if (M != null && E != null) {
					Cuted(M.Value, -E.Value);
				} else {
					if (M != null) {
						Cuted(M.Value);
					} else if (E != null) {
						Cuted(-E.Value);
					}
				}
				return this;
			}
			#endregion
			#region #method# CutedCubic(M, E) 
			public Cubic CutedCubic(Preset M, Preset E) {
				if (M == null && E == null) return this;
				if (M != null && E != null) {
					Cuted(M.Value, -E.Value);
				} else {
					if (M != null) {
						Cuted(M.Value);
					} else if (E != null) {
						Cuted(-E.Value);
					}
				}
				return this;
			}
			#endregion
			public override char Prefix => 'C';
			#region #method# HalfArcM(P) 
			public override List HalfArcM(double Size) {
				var List = new List();
				var SA = Size;
				var SB = -SA;
				var A = SA * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var cmX = this.cmX;
				var cmY = this.cmY;
				var ceX = this.ceX;
				var ceY = this.ceY;
				var EX = this.EX;
				var EY = this.EY;
				var l0 = RootOffset(cmX - MX, cmY - MY, out var l0X, out var l0Y);
				var l1 = RootOffset(ceX - cmX, ceY - cmY, out var l1X, out var l1Y);
				var l2 = RootOffset(EX - ceX, EY - ceY, out var l2X, out var l2Y);
				if (l0 == 0.0 && l1 == 0.0 && l2 == 0.0) return List;
				if (l0 == 0.0) if (l1 > 0.0) { l0X = l1X; l0Y = l1Y; } else { l0X = l2X; l0Y = l2Y; }
				if (l2 == 0.0) if (l1 > 0.0) { l2X = l1X; l2Y = l1Y; } else { l2X = l0X; l2Y = l0Y; }
				var aX = MX + SA * l0X;
				var aY = MY + SA * l0Y;
				var bX = aX;
				var bY = aY;
				var cX = MX + SB * l0X;
				var cY = MY + SB * l0Y;
				var baX = MX;
				var baY = MY;
				var cbX = MX;
				var cbY = MY;
				Rotate1(MX, MY, ref bX, ref bY, 0.25);
				Rotate1(bX, bY, ref baX, ref baY, 0.25);
				Rotate1(bX, bY, ref cbX, ref cbY, 0.75);
				List.AddLast(new Curve(new Cubic(cX, cY, cbX, cbY, bX, bY)));
				List.AddLast(new Curve(new Cubic(bX, bY, baX, baY, aX, aY)));
				return List;
			}
			#endregion
			#region #method# HalfArcE(P) 
			public override List HalfArcE(double Size) {
				var List = new List();
				var SA = Size;
				var SB = -SA;
				var A = SA * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var cmX = this.cmX;
				var cmY = this.cmY;
				var ceX = this.ceX;
				var ceY = this.ceY;
				var EX = this.EX;
				var EY = this.EY;
				var l0 = RootOffset(cmX - MX, cmY - MY, out var l0X, out var l0Y);
				var l1 = RootOffset(ceX - cmX, ceY - cmY, out var l1X, out var l1Y);
				var l2 = RootOffset(EX - ceX, EY - ceY, out var l2X, out var l2Y);
				if (l0 == 0.0 && l1 == 0.0 && l2 == 0.0) return List;
				if (l0 == 0.0) if (l1 > 0.0) { l0X = l1X; l0Y = l1Y; } else { l0X = l2X; l0Y = l2Y; }
				if (l2 == 0.0) if (l1 > 0.0) { l2X = l1X; l2Y = l1Y; } else { l2X = l0X; l2Y = l0Y; }
				var aX = EX + SA * l2X;
				var aY = EY + SA * l2Y;
				var bX = aX;
				var bY = aY;
				var cX = EX + SB * l2X;
				var cY = EY + SB * l2Y;
				var abX = EX;
				var abY = EY;
				var bcX = EX;
				var bcY = EY;
				Rotate1(EX, EY, ref bX, ref bY, -0.25);
				Rotate1(bX, bY, ref abX, ref abY, -0.25);
				Rotate1(bX, bY, ref bcX, ref bcY, -0.75);
				List.AddLast(new Curve(new Cubic(aX, aY, abX, abY, bX, bY)));
				List.AddLast(new Curve(new Cubic(bX, bY, bcX, bcY, cX, cY)));
				return List;
			}
			#endregion
			//#region #method# ExtA(Need, Size, Result) 
			//public bool ExtA(double Need, double Size, ref Cubic Result) {
			//	if (this.Ext(Size, out var Item)) {
			//		this.Div(0.5, out var BA, out var BB);
			//		Item.Div(0.5, out var AA, out var AB);
			//		if (BB.Ext(Size, out var B)) {
			//			var cmcL = Sqrt(AB.MX - B.MX, AB.MY - B.MY);
			//			if (cmcL < Need) {
			//				Result = Item;
			//				return true;
			//			}
			//		}
			//	}
			//	return false;
			//}
			//#endregion
			//#region #method# ExtB(Need, Size, Result) 
			//public bool ExtB(double Need, double Size, ref Cubic Result) {
			//	if (this.Ext(Size, out var Item, true)) {
			//		this.Div(0.5, out var RA, out var RB);
			//		Item.Div(0.5, out var BA, out var BB);
			//		if (RB.Ext(Size, out var B, true)) {
			//			var cecL = Sqrt(BA.EX - B.EX, BA.EY - B.EY);
			//			if (cecL < Need) {
			//				Result = Item;
			//				return true;
			//			}
			//		}
			//	}
			//	return false;
			//}
			//#endregion
			#region #method# Ext(S, A, B) 
			/// <summary>Расширяет кривую на указанную толщину)</summary>
			/// <param name="S">Толщина линии, положительное или отридцательное значение определяет сторону)</param>
			/// <param name="A">Возвращаемая кривая, если длина исходной кривой больше нуля)</param>
			/// <param name="B">Инвертированная кривая с другой стороны, если длина исходной кривой больше нуля)</param>
			/// <returns>Успех если длина исходной кривой больше нуля)</returns>
			public override bool Ext(double S, out Line A, out Line B) {
				var MX = this.MX;
				var MY = this.MY;
				var cmX = this.cmX;
				var cmY = this.cmY;
				var ceX = this.ceX;
				var ceY = this.ceY;
				var EX = this.EX;
				var EY = this.EY;
				var cMX = cmX - MX;
				var cMY = cmY - MY;
				var cEX = EX - ceX;
				var cEY = EY - ceY;
				var lM = Sqrt(cMX, cMY);
				var lE = Sqrt(cEX, cEY);
				if (lM == 0 && lE == 0) return base.Ext(S, out A, out B);
				if (lM == 0) return new Quadratic(MX, MY, ceX, ceY, EX, EY).Ext(S, out A, out B);
				if (lE == 0) return new Quadratic(MX, MY, cmX, cmY, EX, EY).Ext(S, out A, out B);
				var cCX = ceX - cmX;
				var cCY = ceY - cmY;
				var lC = Sqrt(cCX, cCY);
				var lMX = -cMY / lM;
				var lMY = cMX / lM;
				var lEX = -cEY / lE;
				var lEY = cEX / lE;
				var lCX = -cCY / lC;
				var lCY = cCX / lC;

				var aMX = MX + S * lMX;
				var aMY = MY + S * lMY;
				var aEX = EX + S * lEX;
				var aEY = EY + S * lEY;

				var acmX = cmX + S * lCX;
				var acmY = cmY + S * lCY;
				var aceX = ceX + S * lCX;
				var aceY = ceY + S * lCY;
				S = -S;
				var bMX = EX + S * lEX;
				var bMY = EY + S * lEY;
				var bEX = MX + S * lMX;
				var bEY = MY + S * lMY;

				var bcmX = ceX + S * lCX;
				var bcmY = ceY + S * lCY;
				var bceX = cmX + S * lCX;
				var bceY = cmY + S * lCY;
				A = new Cubic(aMX, aMY, acmX, acmY, aceX, aceY, aEX, aEY);
				B = new Cubic(bMX, bMY, bcmX, bcmY, bceX, bceY, bEX, bEY);
				return true;
			}
			#endregion
			#region #method# DivBExtAMBE(S, AMX, AMY, BEX, BEY) 
			public bool DivBExtAMBE(double S, out double AMX, out double AMY, out double BEX, out double BEY) {
				var MX = this.MX; var MY = this.MY;
				var cmX = this.cmX; var cmY = this.cmY;
				var ceX = this.ceX; var ceY = this.ceY;
				var EX = this.EX; var EY = this.EY;
				var x01 = (cmX - MX) / 2 + MX;
				var y01 = (cmY - MY) / 2 + MY;
				var x12 = (ceX - cmX) / 2 + cmX;
				var y12 = (ceY - cmY) / 2 + cmY;
				var x23 = (EX - ceX) / 2 + ceX;
				var y23 = (EY - ceY) / 2 + ceY;
				var x02 = (x12 - x01) / 2 + x01;
				var y02 = (y12 - y01) / 2 + y01;
				var x13 = (x23 - x12) / 2 + x12;
				var y13 = (y23 - y12) / 2 + y12;
				var x03 = (x13 - x02) / 2 + x02;
				var y03 = (y13 - y02) / 2 + y02;
				MX = x03; MY = y03;
				cmX = x13; cmY = y13;
				ceX = x23; ceY = y23;
				var l0 = RootOffset(cmX - MX, cmY - MY, out var l0X, out var l0Y);
				var l1 = RootOffset(ceX - cmX, ceY - cmY, out var l1X, out var l1Y);
				var l2 = RootOffset(EX - ceX, EY - ceY, out var l2X, out var l2Y);
				//var l = l0 + l1 + l2;
				//if (l == 0.0) { A = null; B = null; return false; }
				if (l0 == 0.0) if (l1 > 0.0) { l0X = l1X; l0Y = l1Y; } else { l0X = l2X; l0Y = l2Y; }
				if (l2 == 0.0) if (l1 > 0.0) { l2X = l1X; l2Y = l1Y; } else { l2X = l0X; l2Y = l0Y; }
				AMX = MX + S * l0X;
				AMY = MY + S * l0Y;
				S = -S;
				BEX = MX + S * l0X;
				BEY = MY + S * l0Y;
				return true;
			}
			#endregion
			#region #method# Ext(S, R, I) 
			/// <summary>Расширяет кривую на указанную толщину)</summary>
			/// <param name="S">Толщина линии, положительное или отридцательное значение определяет сторону)</param>
			/// <param name="R">Возвращаемая кривая, если длина исходной кривой больше нуля)</param>
			/// <param name="I">Истина инвертирует значение толщины и направление возвращаемой кривой)</param>
			/// <returns>Успех если длина исходной кривой больше нуля)</returns>
			public override bool Ext(double S, out Line R, bool I = false) {
				var MX = this.MX;
				var MY = this.MY;
				var cmX = this.cmX;
				var cmY = this.cmY;
				var ceX = this.ceX;
				var ceY = this.ceY;
				var EX = this.EX;
				var EY = this.EY;
				var l0 = RootOffset(cmX - MX, cmY - MY, out var l0X, out var l0Y);
				var l1 = RootOffset(ceX - cmX, ceY - cmY, out var l1X, out var l1Y);
				var l2 = RootOffset(EX - ceX, EY - ceY, out var l2X, out var l2Y);
				//var l = l0 + l1 + l2;
				//if (l == 0.0) { R = null; return false; }
				if (l0 == 0.0) if (l1 > 0.0) { l0X = l1X; l0Y = l1Y; } else { l0X = l2X; l0Y = l2Y; }
				if (l2 == 0.0) if (l1 > 0.0) { l2X = l1X; l2Y = l1Y; } else { l2X = l0X; l2Y = l0Y; }
				if (!I) {
					R = new Cubic(MX + S * l0X, MY + S * l0Y, cmX + S * l1X, cmY + S * l1Y, ceX + S * l1X, ceY + S * l1Y, EX + S * l2X, EY + S * l2Y);
				} else {
					S = -S;
					R = new Cubic(EX + S * l2X, EY + S * l2Y, ceX + S * l1X, ceY + S * l1Y, cmX + S * l1X, cmY + S * l1Y, MX + S * l0X, MY + S * l0Y);
				}
				return true;
			}
			#endregion
			#region #method# ExtCw(Size, exA, exB, cwA, cwB) 
			public override bool ExtCw(double Size, ref Line exA, ref Line exB, ref bool cwA, ref bool cwB) {
				if (this.Ext(Size, out var A, out var B)) {
					var S = QualityBut * Size;
					if (S < QualityMin) S = QualityMin; else if (S > QualityMax) S = QualityMax;
					if (this.DivBExtAMBE(Size, out var TAMX, out var TAMY, out var TBEX, out var TBEY)) {
						A.DivC(0.5, out var ABMX, out var ABMY);
						B.DivC(0.5, out var BAEX, out var BAEY);
						var AL = Sqrt(ABMX - TAMX, ABMY - TAMY);
						var BL = Sqrt(BAEX - TBEX, BAEY - TBEY);
						if (AL < S && BL < S) {
							exA = A;
							exB = B;
							cwA = (GetaR1(this.MX, this.MY, A.MX, A.MY, A.EX, A.EY) > 0.5);
							cwB = (GetaR1(this.MX, this.MY, B.MX, B.MY, B.EX, B.EY) > 0.5);
							return true;
						}
					}
				}
				return false;
			}
			#endregion
			#region #method# ExtReturn(Size, Roots) 
			//public override List ExtReturn(double Size, List Roots = null) {
			//	List List = new List();
			//	var DIV = 0.5;
			//	var POS = 0.0;
			//	var ROOT = 0.0;
			//	Line RES = this;
			//	Line TES = this;
			//	var LastRoot = 0.0;
			//	var LastSize = 1.0;
			//	RSLineItem Item = null;
			//	if (Roots != null) {
			//		Item = Roots.Base as RSLineItem;
			//		if (Item != null) {
			//			TES = RES = Item.Line;
			//			LastRoot = Item.Root;
			//			LastSize = Item.Size;
			//			Item = Item.Next as RSLineItem;
			//		}
			//	}
			//	RSABCItem Stab = new RSABCItem(LastRoot, LastSize);
			//	List.AddLast(Stab);
			//	var ResetA = false;
			//	var ResetB = false;
			//	Line NOW;
			//	Line RAM;
			//	Line PreA = null;
			//	Line PreB = null;
			//	RTES:
			//	if (TES.TesReturn(Size, ref PreA, ref PreB, out ResetA, out ResetB)) {
			//		if ((ResetA|| ResetB) && Stab.IsUsed) {
			//			Stab = Stab.AddLastTo(List, ROOT, out LastRoot, out LastSize);
			//			ROOT = 0.0;
			//		}
			//		Stab.Add(PreA, PreB, TES, LastRoot + (ROOT * LastSize), LastSize - (ROOT * LastSize));
			//		POS = 0.0;
			//	} else {
			//		NEXT:
			//		TES.Div(DIV, out NOW, out RAM);
			//		if (NOW.TesReturn(Size, ref PreA, ref PreB, out ResetA, out ResetB)) {
			//			var PDIV = ((1.0 - POS) * DIV);
			//			var RPDIV = ((1.0 - ROOT) * PDIV);
			//			if ((ResetA || ResetB) && Stab.IsUsed) {
			//				Stab = Stab.AddLastTo(List, ROOT, out LastRoot, out LastSize);
			//				ROOT = 0.0;
			//			}
			//			Stab.Add(PreA, PreB, NOW, LastRoot + (ROOT * LastSize), RPDIV * LastSize);
			//			POS += PDIV;
			//			ROOT += RPDIV;
			//			DIV = 0.5;
			//			if ((ResetA || ResetB)) {
			//				RES.Div(POS, out var CUT, out RES);
			//				TES = RES;
			//				POS = 0.0;
			//				goto RTES;
			//			} else {
			//				TES = RAM;
			//			}
			//			goto RTES;
			//		} else { DIV /= 2.0; if (DIV > 0.0) goto NEXT; }
			//	}
			//	if (Item != null) {
			//		List.AddLast(Stab = new RSABCItem(Item.Root, Item.Size));
			//		ROOT = 0.0;
			//		POS = 0.0;
			//		TES = RES = Item.Line;
			//		Item = Item.Next as RSLineItem;
			//		goto RTES;
			//	}
			//	return List;
			//}
			#endregion
			#region #method# AddLinM(P) 
			//public override void AddLinM(PathSource P) {
			//	var S = P.Thickness / 2;
			//	var A = S * Arc14;
			//	var MX = this.MX;
			//	var MY = this.MY;
			//	var cmX = this.cmX;
			//	var cmY = this.cmY;
			//	var ceX = this.ceX;
			//	var ceY = this.ceY;
			//	var EX = this.EX;
			//	var EY = this.EY;
			//	var cmL = Sqrt(MX - cmX, MY - cmY);
			//	var ceL = Sqrt(EX - ceX, EY - ceY);
			//	var meL = Sqrt(MX - EX, MY - EY);
			//	if (cmL > 0.0) {
			//		if (Sqrt(EX - cmX, EY - cmY) > 0.0) {
			//			EX = cmX;
			//			EY = cmY;
			//			meL = cmL;
			//		}
			//	} else if (ceL > 0.0) {
			//		if (Sqrt(MX - ceX, MY - ceY) > 0.0) {
			//			EX = ceX;
			//			EY = ceY;
			//			meL = Sqrt(MX - EX, MY - EY);
			//		}
			//	}
			//	var YX = (EY - MY) / meL * S;
			//	var XY = (MX - EX) / meL * S;
			//	var AX = MX + YX;
			//	var AY = MY + XY;
			//	var BX = MX - YX;
			//	var BY = MY - XY;
			//	P.AddCurve(new Line(BX, BY, AX, AY));
			//}
			#endregion
			#region #method# AddLinE(P) 
			//public override void AddLinE(PathSource P) {
			//	var S = P.Thickness / 2;
			//	var A = S * Arc14;
			//	var MX = this.MX;
			//	var MY = this.MY;
			//	var cmX = this.cmX;
			//	var cmY = this.cmY;
			//	var ceX = this.ceX;
			//	var ceY = this.ceY;
			//	var EX = this.EX;
			//	var EY = this.EY;
			//	var cmL = Sqrt(MX - cmX, MY - cmY);
			//	var ceL = Sqrt(EX - ceX, EY - ceY);
			//	var meL = Sqrt(MX - EX, MY - EY);
			//	if (ceL > 0.0) {
			//		if (Sqrt(MX - ceX, MY - ceY) > 0.0) {
			//			MX = ceX;
			//			MY = ceY;
			//			meL = ceL;
			//		}
			//	} else if (cmL > 0.0) {
			//		if (Sqrt(EX - cmX, EY - cmY) > 0.0) {
			//			MX = cmX;
			//			MY = cmY;
			//			meL = Sqrt(MX - EX, MY - EY);
			//		}
			//	}
			//	var YX = (EY - MY) / meL * S;
			//	var XY = (MX - EX) / meL * S;
			//	var AX = EX + YX;
			//	var AY = EY + XY;
			//	var BX = EX - YX;
			//	var BY = EY - XY;
			//	P.AddCurve(new Line(AX, AY, BX, BY));
			//}
			#endregion
			#region #method# Extrema(Roots) 
			/// <summary>Возвращает массив корней кубической кривой)</summary>
			/// <param name="Roots">Исходный массив корней, как правило нулевой)</param>
			/// <returns>Возвращаемый массив корней)</returns>
			public double[] Extrema(double[] Roots = null) {
				var MX = this.MX;
				var MY = this.MY;
				var cmX = this.cmX;
				var cmY = this.cmY;
				var ceX = this.ceX;
				var ceY = this.ceY;
				var EX = this.EX;
				var EY = this.EY;
				var l0X = cmX - MX;
				var l0Y = cmY - MY;
				var l1X = ceX - cmX;
				var l1Y = ceY - cmY;
				var l2X = EX - ceX;
				var l2Y = EY - ceY;
				Roots = AddBoxRoots(l0X, l1X, l2X, Roots);
				Roots = AddBoxRoots(l0Y, l1Y, l2Y, Roots);
				return Roots;
			}
			#endregion
			#region #property# Linear 
			/// <summary>Возвращает линейность кубической кривой)</summary>
			public bool Linear {
				get {
					var lMcm = Sqrt(cmX - MX, cmY - MY);
					var lEce = Sqrt(EX - ceX, EY - ceY);
					if (lMcm != 0.0 && lEce != 0.0) {
						return Inline(MX, MY, cmX, cmY, ceX, ceY, EX, EY);
					} else {
						if (lMcm > 0.0) {
							return Inline(MX, MY, cmX, cmY, EX, EY);
						} else if (lEce > 0.0) {
							return Inline(EX, EY, ceX, ceY, MX, MY);
						}
					}
					return false;
				}
			}
			#endregion
		}
		#endregion
		#region #class# Quadratic 
		public class Quadratic : Line {
			#region #new# 
			public Quadratic() { }
			#endregion
			#region #new# (MX, MY, QX, QY, EX, EY) 
			public Quadratic(double MX, double MY, double QX, double QY, double EX, double EY) {
				this.MX = MX; this.MY = MY; this.QX = QX; this.QY = QY; this.EX = EX; this.EY = EY;
			}
			#endregion
			public double QX;
			public double QY;
			#region #method# Change(Mod, Inverted) 
			public override Line Change(Change Mod, bool Inverted) {
				var MX = this.MX; var MY = this.MY; var QX = this.QX; var QY = this.QY; var EX = this.EX; var EY = this.EY;
				while (Mod != null) {
					Mod.Modify(ref MX, ref MY, (Mod.Mods & Mods.MX) != 0, (Mod.Mods & Mods.MY) != 0);
					Mod.Modify(ref EX, ref EY, (Mod.Mods & Mods.EX) != 0, (Mod.Mods & Mods.EY) != 0);
					Mod.Modify(ref QX, ref QY, (Mod.Mods & Mods.QX) != 0, (Mod.Mods & Mods.QY) != 0);
					Mod = Mod.Next;
				}
				if (Inverted)
					return new Quadratic(EX, EY, QX, QY, MX, MY);
				return new Quadratic(MX, MY, QX, QY, EX, EY);
			}
			#endregion
			#region #method# To(Context) 
			public override void To(System.Windows.Media.StreamGeometryContext Context) {
				Context.QuadraticBezierTo(new System.Windows.Point(QX, QY), new System.Windows.Point(EX, EY), true, true);
			}
			#endregion
			#region #method# ToPathString 
			public override string ToPathString() {
				var I = System.Globalization.CultureInfo.InvariantCulture;
				return "Q" + QX.ToString(I) + "," + QY.ToString(I) + " " + EX.ToString(I) + "," + EY.ToString(I);
			}
			#endregion
			#region #method# ToCompessedString(Prev) 
			public override string ToCompessedString(Line Prev) {
				var I = System.Globalization.CultureInfo.InvariantCulture;
				return "Q" + QX.ToString(I) + "," + QY.ToString(I) + " " + EX.ToString(I) + "," + EY.ToString(I);
			}
			#endregion
			#region #method# ToString 
			public override string ToString() {
				var I = System.Globalization.CultureInfo.InvariantCulture;
				return "M" + MX.ToString(I) + "," + MY.ToString(I) + "Q" + QX.ToString(I) + "," + QY.ToString(I) + " " + EX.ToString(I) + "," + EY.ToString(I);
			}
			#endregion
			#region #method# Cuted(r0) 
			public Quadratic Cuted(double r0) {
				if ((r0 < 1.0) && (r0 > -1.0)) {
					if (r0 != 0.0) {
						var root = r0 < 0.0 ? 1.0 + r0 : r0;
						var x00 = this.MX;
						var y00 = this.MY;
						var x11 = this.QX;
						var y11 = this.QY;
						var x22 = this.EX;
						var y22 = this.EY;
						var x01 = (x11 - x00) * root + x00;
						var y01 = (y11 - y00) * root + y00;
						var x12 = (x22 - x11) * root + x11;
						var y12 = (y22 - y11) * root + y11;
						var x02 = (x12 - x01) * root + x01;
						var y02 = (y12 - y01) * root + y01;
						if (r0 < 0.0) {
							this.MX = x00; this.MY = y00;
							this.QX = x01; this.QY = y01;
							this.EX = x02; this.EY = y02;
						} else {
							this.MX = x02; this.MY = y02;
							this.QX = x12; this.QY = y12;
							this.EX = x22; this.EY = y22;
						}
					}
				}
				return this;
			}
			#endregion
			#region #method# Cuted(r0, r1) 
			public Quadratic Cuted(double r0, double r1) {
				if ((r0 < 1.0) && (r0 > -1.0)) {
					r1 = (r1 / (1.0 - r0));
					while (r0 != 0.0) {
						var root = r0 < 0.0 ? 1.0 + r0 : r0;
						var x00 = this.MX;
						var y00 = this.MY;
						var x11 = this.QX;
						var y11 = this.QY;
						var x22 = this.EX;
						var y22 = this.EY;
						var x01 = (x11 - x00) * root + x00;
						var y01 = (y11 - y00) * root + y00;
						var x12 = (x22 - x11) * root + x11;
						var y12 = (y22 - y11) * root + y11;
						var x02 = (x12 - x01) * root + x01;
						var y02 = (y12 - y01) * root + y01;
						if (r0 < 0.0) {
							this.MX = x00; this.MY = y00;
							this.QX = x01; this.QY = y01;
							this.EX = x02; this.EY = y02;
						} else {
							this.MX = x02; this.MY = y02;
							this.QX = x12; this.QY = y12;
							this.EX = x22; this.EY = y22;
						}
						r0 = r1; r1 = 0.0;
					}
				}
				return this;
			}
			#endregion
			#region #method# Cuted(M, E) 
			public override Line Cuted(Preset M, Preset E) {
				if (M == null && E == null) return this;
				if (M != null && E != null) {
					Cuted(M.Value, -E.Value);
				} else {
					if (M != null) {
						Cuted(M.Value);
					} else if (E != null) {
						Cuted(-E.Value);
					}
				}
				return this;
			}
			#endregion
			public override char Prefix => 'Q';
			#region #method# HalfArcM(P) 
			public override List HalfArcM(double Size) {
				var List = new List();
				var SA = Size;
				var SB = -SA;
				var A = SA * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var QX = this.QX;
				var QY = this.QY;
				var EX = this.EX;
				var EY = this.EY;
				var l0 = RootOffset(QX - MX, QY - MY, out var l0X, out var l0Y);
				var l1 = RootOffset(EX - QX, EY - QY, out var l1X, out var l1Y);
				if (l0 == 0.0 && l1 == 0.0) return List;
				var aX = MX + SA * l0X;
				var aY = MY + SA * l0Y;
				var bX = aX;
				var bY = aY;
				var cX = MX + SB * l0X;
				var cY = MY + SB * l0Y;
				var baX = MX;
				var baY = MY;
				var cbX = MX;
				var cbY = MY;
				Rotate1(MX, MY, ref bX, ref bY, 0.25);
				Rotate1(bX, bY, ref baX, ref baY, 0.25);
				Rotate1(bX, bY, ref cbX, ref cbY, 0.75);
				List.AddLast(new Curve(new Cubic(cX, cY, cbX, cbY, bX, bY)));
				List.AddLast(new Curve(new Cubic(bX, bY, baX, baY, aX, aY)));
				return List;
			}
			#endregion
			#region #method# HalfArcE(P) 
			public override List HalfArcE(double Size) {
				var List = new List();
				var SA = Size;
				var SB = -SA;
				var A = SA * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var QX = this.QX;
				var QY = this.QY;
				var EX = this.EX;
				var EY = this.EY;
				var l0 = RootOffset(QX - MX, QY - MY, out var l0X, out var l0Y);
				var l1 = RootOffset(EX - QX, EY - QY, out var l1X, out var l1Y);
				if (l0 == 0.0 && l1 == 0.0) return List;
				var aX = EX + SA * l1X;
				var aY = EY + SA * l1Y;
				var bX = aX;
				var bY = aY;
				var cX = EX + SB * l1X;
				var cY = EY + SB * l1Y;
				var abX = EX;
				var abY = EY;
				var bcX = EX;
				var bcY = EY;
				Rotate1(EX, EY, ref bX, ref bY, -0.25);
				Rotate1(bX, bY, ref abX, ref abY, -0.25);
				Rotate1(bX, bY, ref bcX, ref bcY, -0.75);
				List.AddLast(new Curve(new Cubic(aX, aY, abX, abY, bX, bY)));
				List.AddLast(new Curve(new Cubic(bX, bY, bcX, bcY, cX, cY)));
				return List;
			}
			#endregion
			#region #method# Div(root, A, B) 
			public override void Div(double root, out Line A, out Line B) {
				var x00 = MX;
				var y00 = MY;
				var x11 = QX;
				var y11 = QY;
				var x22 = EX;
				var y22 = EY;
				var x01 = (x11 - x00) * root + x00;
				var y01 = (y11 - y00) * root + y00;
				var x12 = (x22 - x11) * root + x11;
				var y12 = (y22 - y11) * root + y11;
				var x02 = (x12 - x01) * root + x01;
				var y02 = (y12 - y01) * root + y01;
				A = new Quadratic(x00, y00, x01, y01, x02, y02);
				B = new Quadratic(x02, y02, x12, y12, x22, y22);
			}
			#endregion
			#region #method# DivA(root) 
			public override Line DivA(double root) {
				var x00 = MX;
				var y00 = MY;
				var x11 = QX;
				var y11 = QY;
				var x22 = EX;
				var y22 = EY;
				var x01 = (x11 - x00) * root + x00;
				var y01 = (y11 - y00) * root + y00;
				var x12 = (x22 - x11) * root + x11;
				var y12 = (y22 - y11) * root + y11;
				var x02 = (x12 - x01) * root + x01;
				var y02 = (y12 - y01) * root + y01;
				return new Quadratic(x00, y00, x01, y01, x02, y02);
			}
			#endregion
			#region #method# DivB(root) 
			public override Line DivB(double root) {
				var x00 = MX;
				var y00 = MY;
				var x11 = QX;
				var y11 = QY;
				var x22 = EX;
				var y22 = EY;
				var x01 = (x11 - x00) * root + x00;
				var y01 = (y11 - y00) * root + y00;
				var x12 = (x22 - x11) * root + x11;
				var y12 = (y22 - y11) * root + y11;
				var x02 = (x12 - x01) * root + x01;
				var y02 = (y12 - y01) * root + y01;
				return new Quadratic(x02, y02, x12, y12, x22, y22);
			}
			#endregion
			#region #method# DivC(root, X, Y) 
			public override void DivC(double root, out double X, out double Y) {
				var x00 = MX;
				var y00 = MY;
				var x11 = QX;
				var y11 = QY;
				var x22 = EX;
				var y22 = EY;
				var x01 = (x11 - x00) * root + x00;
				var y01 = (y11 - y00) * root + y00;
				var x12 = (x22 - x11) * root + x11;
				var y12 = (y22 - y11) * root + y11;
				X = (x12 - x01) * root + x01;
				Y = (y12 - y01) * root + y01;
			}
			#endregion
			#region #method# Ext(S, A, B) 
			/// <summary>Расширяет кривую на указанную толщину)</summary>
			/// <param name="S">Толщина линии, положительное или отридцательное значение определяет сторону)</param>
			/// <param name="A">Возвращаемая кривая, если длина исходной кривой больше нуля)</param>
			/// <param name="B">Инвертированная кривая с другой стороны, если длина исходной кривой больше нуля)</param>
			/// <returns>Успех если длина исходной кривой больше нуля)</returns>
			public override bool Ext(double S, out Line A, out Line B) {
				var MX = this.MX;
				var MY = this.MY;
				var QX = this.QX;
				var QY = this.QY;
				var EX = this.EX;
				var EY = this.EY;
				var cMX = QX - MX;
				var cMY = QY - MY;
				var cEX = EX - QX;
				var cEY = EY - QY;
				var lM = Sqrt(cMX, cMY);
				var lE = Sqrt(cEX, cEY);
				if (lM == 0 || lE == 0) return base.Ext(S, out A, out B);
				var lMX = -cMY / lM;
				var lMY = cMX / lM;
				var lEX = -cEY / lE;
				var lEY = cEX / lE;

				var aMX = MX + S * lMX;
				var aMY = MY + S * lMY;
				var aEX = EX + S * lEX;
				var aEY = EY + S * lEY;

				var aQX = QX + S * lMX;
				var aQY = QY + S * lMY;
				S = -S;
				var bMX = EX + S * lEX;
				var bMY = EY + S * lEY;
				var bEX = MX + S * lMX;
				var bEY = MY + S * lMY;

				var bQX = QX + S * lEX;
				var bQY = QY + S * lEY;
				A = new Quadratic(aMX, aMY, aQX, aQY, aEX, aEY);
				B = new Quadratic(bMX, bMY, bQX, bQY, bEX, bEY);
				return true;
			}
			#endregion
			#region #method# Ext(S, R, I) 
			/// <summary>Расширяет кривую на указанную толщину)</summary>
			/// <param name="S">Толщина линии, положительное или отридцательное значение определяет сторону)</param>
			/// <param name="R">Возвращаемая кривая, если длина исходной кривой больше нуля)</param>
			/// <param name="I">Истина инвертирует значение толщины и направление возвращаемой кривой)</param>
			/// <returns>Успех если длина исходной кривой больше нуля)</returns>
			public override bool Ext(double S, out Line R, bool I = false) {
				var MX = this.MX;
				var MY = this.MY;
				var QX = this.QX;
				var QY = this.QY;
				var EX = this.EX;
				var EY = this.EY;
				var l0 = RootOffset(QX - MX, QY - MY, out var l0X, out var l0Y);
				var l1 = RootOffset(EX - QX, EY - QY, out var l1X, out var l1Y);
				if (l0 == 0.0 || l1 == 0.0) return base.Ext(S, out R, I);
				if (!I) {
					R = new Quadratic(
					MX + S * l0X,
					MY + S * l0Y,
					QX + S * l0X,
					QY + S * l0Y,
					EX + S * l1X,
					EY + S * l1Y);
				} else {
					S = -S;
					R = new Quadratic(
					EX + S * l1X,
					EY + S * l1Y,
					QX + S * l0X,
					QY + S * l0Y,
					MX + S * l0X,
					MY + S * l0Y);
				}
				return true;
			}
			#endregion
			#region #method# DivBExtAMBE(S, AMX, AMY, BEX, BEY) 
			public bool DivBExtAMBE(double S, out double AMX, out double AMY, out double BEX, out double BEY) {
				var MX = this.MX; var MY = this.MY;
				var QX = this.QX; var QY = this.QY;
				var EX = this.EX; var EY = this.EY;
				var x00 = MX;
				var y00 = MY;
				var x11 = QX;
				var y11 = QY;
				var x22 = EX;
				var y22 = EY;
				var x01 = (x11 - x00) / 2 + x00;
				var y01 = (y11 - y00) / 2 + y00;
				var x12 = (x22 - x11) / 2 + x11;
				var y12 = (y22 - y11) / 2 + y11;
				var x02 = (x12 - x01) / 2 + x01;
				var y02 = (y12 - y01) / 2 + y01;
				MX = x02; MY = y02;
				QX = x12; QY = y12;
				var l0 = RootOffset(QX - MX, QY - MY, out var l0X, out var l0Y);
				var l1 = RootOffset(EX - QX, EY - QY, out var l2X, out var l2Y);
				AMX = MX + S * l0X;
				AMY = MY + S * l0Y;
				S = -S;
				BEX = MX + S * l0X;
				BEY = MY + S * l0Y;
				return true;
			}
			#endregion
			#region #method# ExtCw(Size, exA, exB, cwA, cwB) 
			public override bool ExtCw(double Size, ref Line exA, ref Line exB, ref bool cwA, ref bool cwB) {
				if (this.Ext(Size, out var A, out var B)) {
					var S = QualityBut * Size;
					if (S < QualityMin) S = QualityMin; else if (S > QualityMax) S = QualityMax;
					if (this.DivBExtAMBE(Size, out var TAMX, out var TAMY, out var TBEX, out var TBEY)) {
						A.DivC(0.5, out var ABMX, out var ABMY);
						B.DivC(0.5, out var BAEX, out var BAEY);
						var AL = Sqrt(ABMX - TAMX, ABMY - TAMY);
						var BL = Sqrt(BAEX - TBEX, BAEY - TBEY);
						if (AL < S && BL < S) {
							exA = A;
							exB = B;
							cwA = (GetaR1(this.MX, this.MY, A.MX, A.MY, A.EX, A.EY) > 0.5);
							cwB = (GetaR1(this.MX, this.MY, B.MX, B.MY, B.EX, B.EY) > 0.5);
							return true;
						}
					}
				}
				return false;
			}
			#endregion
		}
		#endregion
		#region #method# Invert 
		public void Invert() {
			this.ProcessingFigure?.End();
			if (this.Inverted) {
				this.Inverted = false;
			} else {
				this.Inverted = true;
			}
		}
		#endregion
		#region #method# AddItemArc(Val, Acw) 
		public Curve AddItemArc(Line Val, bool Acw = false) {
			return AddCurve(Val.ToArcC(Acw));
		}
		#endregion
		#region #method# AddItemArc(MX, MY, EX, EY, Acw) 
		public Curve AddItemArc(double MX, double MY, double EX, double EY, bool Acw = false) {
			return AddItemArc(new Line(MX, MY, EX, EY), Acw);
		}
		#endregion
		#region #method# AddBoneArc(Val, Acw) 
		public Curve AddBoneArc(Line Val, bool Acw = false) {
			return AddBone(Val.ToArcC(Acw));
		}
		#endregion
		#region #method# AddBoneArc(MX, MY, EX, EY, Acw) 
		public Curve AddBoneArc(double MX, double MY, double EX, double EY, bool Acw = false) {
			return AddBone(new Line(MX, MY, EX, EY).ToArcC(Acw));
		}
		#endregion
		#region #method# AddOrc(X, Y, R, D) 
		/// <summary>Добавляет кольцо указанного радиуса и толщины)</summary>
		/// <param name="X">Горизонтальный центр кольца)</param>
		/// <param name="Y">Вертикальный центр кольца)</param>
		/// <param name="R">Радиус кольца)</param>
		/// <param name="hole">Наличие дыры)</param>
		public void AddOrc(double X, double Y, double R, bool hole = true) {
			if (R > 0.0) {
				BeginFz();
				var x00 = X; var y00 = Y - R; var x01 = X + R; var y01 = Y;
				var x10 = X + R; var y10 = Y; var x11 = X; var y11 = Y + R;
				var x20 = X; var y20 = Y + R; var x21 = X - R; var y21 = Y;
				var x30 = X - R; var y30 = Y; var x31 = X; var y31 = Y - R;
				var D = this.Thickness;
				D /= 2;
				if (D > 0.0) {
					AddItemArc(x00, y00 - D, x01 + D, y01);
					AddItemArc(x10 + D, y10, x11, y11 + D);
					AddItemArc(x20, y20 + D, x21 - D, y21);
					AddItemArc(x30 - D, y30, x31, y31 - D);
					if (hole && R - D > 0.0) {
						BeginHz();
						Invert();
						AddItemArc(x00, y00 + D, x01 - D, y01);
						AddItemArc(x10 - D, y10, x11, y11 - D);
						AddItemArc(x20, y20 - D, x21 + D, y21);
						AddItemArc(x30 + D, y30, x31, y31 + D);
						Invert();
					}
				}
				if (IsBoned) {
					AddBoneArc(x00, y00, x01, y01);
					AddBoneArc(x10, y10, x11, y11);
					AddBoneArc(x20, y20, x21, y21);
					AddBoneArc(x30, y30, x31, y31);
				}
				End();
			}
		}
		#endregion
		#region #method# AddKrug(X, Y, R) 
		/// <summary>Добавляет круг указанного радиуса)</summary>
		/// <param name="X">Горизонтальный центр круга)</param>
		/// <param name="Y">Вертикальный центр круга)</param>
		/// <param name="R">Радиус круга)</param>
		public void AddKrug(double X, double Y, double R) {
			BeginFz();
			AddItemArc(X, Y - R, X + R, Y);
			AddItemArc(X + R, Y, X, Y + R);
			AddItemArc(X, Y + R, X - R, Y);
			AddItemArc(X - R, Y, X, Y - R);
			if (IsBoned) {
				AddBoneArc(X, Y - R, X + R, Y);
				AddBoneArc(X + R, Y, X, Y + R);
				AddBoneArc(X, Y + R, X - R, Y);
				AddBoneArc(X - R, Y, X, Y - R);
			}
			End();
		}
		#endregion
		#region #method# AddArc00(x0, y0, x1, y1) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddArc00(double x0, double y0, double x1, double y1) {
			this.IsRoundM = false;
			this.IsRoundE = false;
			AddArcT(x0, y0, x1, y1);
		}
		#endregion
		#region #method# AddArc01(x0, y0, x1, y1) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddArc01(double x0, double y0, double x1, double y1) {
			this.IsRoundM = false;
			this.IsRoundE = true;
			AddArcT(x0, y0, x1, y1);
		}
		#endregion
		#region #method# AddArc10(x0, y0, x1, y1) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddArc10(double x0, double y0, double x1, double y1) {
			this.IsRoundM = true;
			this.IsRoundE = false;
			AddArcT(x0, y0, x1, y1);
		}
		#endregion
		#region #method# AddArc11(x0, y0, x1, y1) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddArc11(double x0, double y0, double x1, double y1) {
			this.IsRoundM = true;
			this.IsRoundE = true;
			AddArcT(x0, y0, x1, y1);
		}
		#endregion
		#region #method# AddArcT(x0, y0, x1, y1) 
		public void AddArcT(double x0, double y0, double x1, double y1) {
			var V = new Line(x0, y0, x1, y1).ToArcC();
			AddCubicT(V.MX, V.MY, V.cmX, V.cmY, V.ceX, V.ceY, V.EX, V.EY);
		}
		#endregion
		#region #method# AddYrc00(x0, y0, x1, y1) 
		public void AddYrc00(double x0, double y0, double x1, double y1, bool cw = false) {
			var x00 = x0;
			var y00 = y0;
			var x11 = x1;
			var y11 = y1;
			if ((y0 < y1) ^ cw) {
				y00 += ((x0 - x1) * Arc14);
				y11 += ((x1 - x0) * Arc14);
			} else {
				y00 += ((x1 - x0) * Arc14);
				y11 += ((x0 - x1) * Arc14);
			}
			AddCubicT(x0, y0, x00, y00, x11, y11, x1, y1);
		}
		#endregion
		#region #method# AddXrc00(x0, y0, x1, y1) 
		public void AddXrc00(double x0, double y0, double x1, double y1, bool cw = false) {
			var x00 = x0;
			var y00 = y0;
			var x11 = x1;
			var y11 = y1;
			if ((y0 < y1) ^ cw) {
				x00 += ((y0 - y1) * Arc14);
				x11 += ((y1 - y0) * Arc14);
			} else {
				x00 += ((y1 - y0) * Arc14);
				x11 += ((y0 - y1) * Arc14);
			}
			AddCubicT(x0, y0, x00, y00, x11, y11, x1, y1);
		}
		#endregion
		#region #struct# DOT 
		public struct DOT {
			public double X;
			public double Y;
			public DOT(double X, double Y) { this.X = X; this.Y = Y; }
			public static DOT operator +(DOT A, DOT B) {
				A.X += B.X;
				A.Y += B.Y;
				return A;
			}
			public static DOT operator -(DOT Prev, DOT Last) {
				Prev.X = 2.0 * Last.X - Prev.X;
				Prev.Y = 2.0 * Last.Y - Prev.Y;
				return Prev;
			}
		}
		#endregion
		#region #method# Parse(Val, Index, Count) 
		public void Parse(string Val, int Index = 0, int Count = 0) {
			if (Val != null) {
				if (Count == 0) Count = Val.Length;
				char Chr = ' ';
				bool Pre = false;
				char Lot = ' ';
				while (Index < Count && char.IsWhiteSpace(Val, Index)) { Index++; }
				if (Index < Count && Val[Index] == 'F') {
					Index++;
					while (Index < Count && char.IsWhiteSpace(Val, Index)) { Index++; }
					Chr = Val[Index];
					if (Index == Count || (Chr != '0' && Chr != '1')) throw new System.FormatException("IllegalToken F");
					this.IsUnited = (Chr == '1');
					Index++;
				}
				var Base = new DOT();
				var Prev = new DOT();
				var Last = new DOT();
				while (ParseToken(Val, ref Index, Count, ref Chr, ref Pre)) {
					if (Chr != 'm') throw new System.FormatException("NeededToken M UnexpectedToken " + Chr);
					switch (Chr) {
						#region #case# 'm' Начало 
						case 'm': {
								BeginF();
								if (ParsePoint(Val, ref Index, Count, ref Base)) {
									while (ParsePoint(Val, ref Index, Count, ref Last)) {
										if (Pre) Last += Base;
										AddCurve(Base.X, Base.Y, Last.X, Last.Y);
										Base = Last;
									}
								}
								Lot = 'l';
							}
							continue;
						#endregion
						#region #case# 'l' Линия 
						case 'l': {
								while (ParsePoint(Val, ref Index, Count, ref Last)) {
									if (Pre) Last += Base;
									AddCurve(Base.X, Base.Y, Last.X, Last.Y);
									Base = Last;
								}
								Lot = 'l';
							}
							continue;
						#endregion
						#region #case# 'h' Горизонтальная линия 
						case 'h': {
								while (ParseNumber(Val, ref Index, Count, ref Last.X)) {
									if (Pre) Last.X += Base.X;
									AddCurve(Base.X, Base.Y, Last.X, Last.Y);
									Base = Last;
								}
								Lot = 'l';
							}
							continue;
						#endregion
						#region #case# 'v' Вертикальная линия 
						case 'v': {
								while (ParseNumber(Val, ref Index, Count, ref Last.Y)) {
									if (Pre) Last.Y += Base.Y;
									AddCurve(Base.X, Base.Y, Last.X, Last.Y);
									Base = Last;
								}
								Lot = 'l';
							}
							continue;
						#endregion
						#region #case# 'a' Элипс 
						case 'a': {
								//do {
								//	double width = this.ReadNumber(false);
								//	double height = this.ReadNumber(true);
								//	double rotationAngle = this.ReadNumber(true);
								//	bool isLargeArc = this.ReadBool();
								//	bool flag2 = this.ReadBool();
								//	_lastPoint = this.ReadPoint(Chr, true);
								//	context.ArcTo(this._lastPoint, new Size(width, height), rotationAngle, isLargeArc, flag2 ? SweepDirection.Clockwise : SweepDirection.Counterclockwise, true, false);
								//}
								//while (this.IsNumber(true));
								throw new System.FormatException("NotSupportedToken " + Chr);
								Lot = 'a';
							}
							continue;
						#endregion
						#region #case# 'q' Квадратик 
						case 'q': {
								while (ParsePoint(Val, ref Index, Count, ref Prev)) {
									if (Pre) Prev += Base;
									ParseCommaPoint(Val, ref Index, Count, ref Last);
									if (Pre) Last += Base;
									AddCurve(Base.X, Base.Y, Prev.X, Prev.Y, Last.X, Last.Y);
									Base = Last;
								}
								Lot = 'q';
							}
							continue;
						#endregion
						#region #case# 't' Квадратик часть 
						case 't': {
								if (Lot == 'q') { Prev = Prev - Last; } else { Prev = Last; }
								while (ParsePoint(Val, ref Index, Count, ref Last)) {
									if (Pre) Last += Base;
									AddCurve(Base.X, Base.Y, Prev.X, Prev.Y, Last.X, Last.Y);
									Base = Last;
								}
								Lot = 'q';
							}
							continue;
						#endregion
						#region #case# 'c' Кубик 
						case 'c': {
								DOT Next = new DOT();
								while (ParsePoint(Val, ref Index, Count, ref Next)) {
									if (Pre) Next += Base;
									ParseCommaPoint(Val, ref Index, Count, ref Prev);
									if (Pre) Prev += Base;
									ParseCommaPoint(Val, ref Index, Count, ref Last);
									if (Pre) Last += Base;
									AddCurve(Base.X, Base.Y, Next.X, Next.Y, Prev.X, Prev.Y, Last.X, Last.Y);
									Base = Last;
								}
								Lot = 'c';
							}
							continue;
						#endregion
						#region #case# 's' Кубик часть 
						case 's': {
								DOT Next = new DOT();
								if (Lot == 'c') { Next = Prev - Last; } else { Next = Last; }
								while (ParsePoint(Val, ref Index, Count, ref Next)) {
									if (Pre) Next += Base;
									ParseCommaPoint(Val, ref Index, Count, ref Prev);
									if (Pre) Prev += Base;
									ParseCommaPoint(Val, ref Index, Count, ref Last);
									if (Pre) Last += Base;
									AddCurve(Base.X, Base.Y, Next.X, Next.Y, Prev.X, Prev.Y, Last.X, Last.Y);
									Base = Last;
								}
								Lot = 'c';
							}
							continue;
						#endregion
						#region #case# 'z' Замкнутый 
						case 'z': {
								ProcessingFigure.IsClozed = true;
								End();
								Last = Base;
							}
							continue;
						#endregion
						default: throw new System.FormatException("UnexpectedToken " + Chr);
					}
				}
			}
		}
		#endregion
		#region #method# ParseToken(Val, Inx, Cnt, Chr, Pre) 
		private static bool ParseToken(string Val, ref int Inx, int Cnt, ref char Chr, ref bool Pre) {
			var Index = Inx;
			while (Index < Cnt && char.IsWhiteSpace(Val, Index)) { Index++; }
			Inx = Index;
			if (Index < Cnt) {
				var Char = Val[Index];
				if ((Char >= 'A' && Char <= 'Z')) {
					Chr = (char)('a' + (Char - 'A'));
					Pre = false;
					Inx = Index + 1;
					return true;
				} else if ((Char >= 'a' && Char <= 'z')) {
					Chr = Char;
					Pre = true;
					Inx = Index + 1;
					return true;
				}
			}
			return false;
		}
		#endregion
		#region #method# ParseCommaPoint(Val, Inx, Cnt, Dot) 
		private static bool ParseCommaPoint(string Val, ref int Inx, int Cnt, ref DOT Dot) {
			var Index = Inx;
			DOT Num = new DOT();
			while (Index < Cnt && char.IsWhiteSpace(Val, Index)) { Index++; }
			if (Index < Cnt && Val[Index] == ',') { Index++; }
			if (ParseNumber(Val, ref Index, Cnt, ref Num.X)) {
				while (Index < Cnt && char.IsWhiteSpace(Val, Index)) { Index++; }
				if (Index < Cnt && Val[Index] == ',') { Index++; }
				if (ParseNumber(Val, ref Index, Cnt, ref Num.Y)) {
					Inx = Index;
					Dot = Num;
					return true;
				}
			}
			return false;
		}
		#endregion
		#region #method# ParsePoint(Val, Inx, Cnt, Dot) 
		private static bool ParsePoint(string Val, ref int Inx, int Cnt, ref DOT Dot) {
			var Index = Inx;
			DOT Num = new DOT();
			if (ParseNumber(Val, ref Index, Cnt, ref Num.X)) {
				while (Index < Cnt && char.IsWhiteSpace(Val, Index)) { Index++; }
				if (Index < Cnt && Val[Index] == ',') { Index++; }
				if (ParseNumber(Val, ref Index, Cnt, ref Num.Y)) {
					Inx = Index;
					Dot = Num;
					return true;
				}
			}
			return false;
		}
		#endregion
		#region #method# ParseNumber(Val, Inx, Cnt, Num) 
		private static bool ParseNumber(string Val, ref int Inx, int Cnt, ref double Num) {
			var Index = Inx;
			while (Index < Cnt && char.IsWhiteSpace(Val, Index)) { Index++; }
			Inx = Index;
			char Char;
			bool Negative = false;
			if (Index < Cnt) {
				Char = Val[Index];
				if (Char == 'N' || Char == 'n') {
					Inx = Index + 3;
					Num = double.NaN;
					return true;
				}
			}
			int Start = Index;
			if (Index < Cnt) {
				Char = Val[Index];
				if (Char == '-' || Char == '+') { Index++; }
				if (Char == '-') { Negative = true; }
				if (Char == '+') { Start++; }
			}
			if (Index < Cnt) {
				Char = Val[Index];
				if (Char == 'I' || Char == 'i') {
					Inx = Index + 8;
					Num = Negative ? double.NegativeInfinity : double.PositiveInfinity;
					return true;
				}
			}
			while (Index < Cnt && Val[Index] >= '0' && Val[Index] <= '9') { Index++; }
			if (Index < Cnt && Val[Index] == '.') {
				Index++;
				while (Index < Cnt && Val[Index] >= '0' && Val[Index] <= '9') { Index++; }
			}
			if (Index < Cnt && (Val[Index] == 'E' || Val[Index] == 'e')) {
				Index++;
				if (Index < Cnt && Val[Index] == '-' || Val[Index] == '+') { Index++; }
				while (Index < Cnt && Val[Index] >= '0' && Val[Index] <= '9') { Index++; }
			}
			if (double.TryParse(Val.Substring(Start, Index - Start), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out Num)) {
				Inx = Index;
				return true;
			}
			return false;
		}
		#endregion
		#region #property# Uncompessed 
		public string Uncompessed {
			get {
				string Result = "";
				if (Figures != null) {
					var Figure = Figures.Base as Figure;
					while (Figure != null) {
						var Curve = Figure.Curves.Base as Curve;
						while (Curve != null) {
							Result += Curve.Line.ToString();
							Curve = Curve.Next as Curve;
						}
						Figure = Figure.Next as Figure;
					}
				}
				return Result;
			}
		}
		#endregion
		#region #property# Compessed 
		public string Compessed {
			get {
				string Result = "";
				if (Figures != null) {
					var Figure = Figures.Base as Figure;
					while (Figure != null) {
						var Curves = Figure.Curves;
						if (Curves != null && Curves.Count > 0) {
							var Item = Curves.Base as Curve;
							Curve Prev = null;
							while (Item != null) {
								Result += Item.Line.ToCompessedString(Prev?.Line);
								Prev = Item;
								Item = Item.Next as Curve;
							}
							if (Figure.IsClozed) Result += "z";
						}
						Figure = Figure.Next as Figure;
					}
				}
				return Result;
			}
		}
		#endregion
		#region #method# AddLin00(x0, y0, x1, y1) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddLin00(double x0, double y0, double x1, double y1) {
			this.IsRoundM = false;
			this.IsRoundE = false;
			AddLinT(x0, y0, x1, y1);
		}
		#endregion
		#region #method# AddLin01(x0, y0, x1, y1) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddLin01(double x0, double y0, double x1, double y1) {
			this.IsRoundM = false;
			this.IsRoundE = true;
			AddLinT(x0, y0, x1, y1);
		}
		#endregion
		#region #method# AddLin10(x0, y0, x1, y1) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddLin10(double x0, double y0, double x1, double y1) {
			this.IsRoundM = true;
			this.IsRoundE = false;
			AddLinT(x0, y0, x1, y1);
		}
		#endregion
		#region #method# AddLin11(x0, y0, x1, y1) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddLin11(double x0, double y0, double x1, double y1) {
			this.IsRoundM = true;
			this.IsRoundE = true;
			AddLinT(x0, y0, x1, y1);
		}
		#endregion
		#region #method# AddLinT(x0, y0, x1, y1) 
		public void AddLinT(double x0, double y0, double x1, double y1) {
			var Size = this.Thickness / 2;
			var IsRoundM = this.IsRoundM;
			var IsRoundE = this.IsRoundE;
			var RootM = this.RootM; this.RootM = null;
			var RootE = this.RootE; this.RootE = null;
			var Bone = new Line(x0, y0, x1, y1).Cuted(RootM, RootE);
			if (IsBoned) { AddBone(Bone); }
			BeginFz();
			var list = new List();
			list.AddLast(Bone.HalfArcM(Size));
			Bone.Ext(Size, out var A, out var B);
			list.AddLast(new Curve(A));
			list.AddLast(Bone.HalfArcE(Size));
			list.AddLast(new Curve(B));
			for (var I = list.Base as Curve; I != null; I = I.Next as Curve) {
				AddCurve(I.Line);
			}
			End();
		}
		#endregion
		#region #method# AddCubic00(x0, y0, x1, y1, x2, y2, x3, y3) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddCubic00(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3) {
			this.IsRoundM = false;
			this.IsRoundE = false;
			AddCubicT(x0, y0, x1, y1, x2, y2, x3, y3);
		}
		#endregion
		#region #method# AddCubic01(x0, y0, x1, y1, x2, y2, x3, y3) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddCubic01(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3) {
			this.IsRoundM = false;
			this.IsRoundE = true;
			AddCubicT(x0, y0, x1, y1, x2, y2, x3, y3);
		}
		#endregion
		#region #method# AddCubic10(x0, y0, x1, y1, x2, y2, x3, y3) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddCubic10(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3) {
			this.IsRoundM = true;
			this.IsRoundE = false;
			AddCubicT(x0, y0, x1, y1, x2, y2, x3, y3);
		}
		#endregion
		#region #method# AddCubic11(x0, y0, x1, y1, x2, y2, x3, y3) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public void AddCubic11(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3) {
			this.IsRoundM = true;
			this.IsRoundE = true;
			AddCubicT(x0, y0, x1, y1, x2, y2, x3, y3);
		}
		#endregion
		#region #method# AddCubicT(x0, y0, x1, y1, x2, y2, x3, y3) 
		public void AddCubicT(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3) {
			var Size = this.Thickness / 2;
			var IsRoundM = this.IsRoundM;
			var IsRoundE = this.IsRoundE;
			var RootM = this.RootM; this.RootM = null;
			var RootE = this.RootE; this.RootE = null;
			var Bone = new Cubic(x0, y0, x1, y1, x2, y2, x3, y3).CutedCubic(RootM, RootE);
			if (IsBoned) { AddBone(Bone); }
			BeginFz();
			var Roots = new double[0];
			Roots = Bone.Extrema(Roots);
			//Roots = AddRoots(0.5, Roots);
			var Linear = Bone.Linear;
			var LinearRounds = Linear && (IsRoundM || IsRoundE);

			var List = Bone.RootsList(Roots);
			var Lll = Bone.ExtCw(Size, List);
			var Li = Lll.Base as Stab;
			bool first = true;
			while (Li != null) {
				var list = new List();
				if (Li.C.Base != null && ((Linear && (IsRoundM || IsRoundE)) || (!Linear && IsRoundM && first))) {
					list.AddLast(((Curve)Li.C.Base).Line.HalfArcM(Size));
					if (!Linear) first = false;
				}
				Curve elseA = null;
				Curve elseB = null;
				if (!Li.ResetA && Li.ResetB) {
					var ABase = Li.A.Base as Curve;
					var ALast = Li.A.Last as Curve;
					var BLast = Li.B.Last as Curve;
					var BBase = Li.B.Base as Curve;
					var aX = 0.0;
					var aY = 0.0;
					if (IntersectLines(
						ABase.Line.MX, ABase.Line.MY, BLast.Line.EX, BLast.Line.EY,
						ALast.Line.EX, ALast.Line.EY, BBase.Line.MX, BBase.Line.MY,
						ref aX, ref aY)) {
						elseA = new Curve(ABase.Line.MX, ABase.Line.MY, aX, aY);
					} else {
						var CBase = Li.C.Base as Curve;
						var CLast = Li.C.Last as Curve;
						elseA = new Curve(CBase.Line.MX, CBase.Line.MY, ALast.Line.MX, ALast.Line.MY);
					}
				}
				if (!Li.ResetB && Li.ResetA) {
					var ABase = Li.A.Base as Curve;
					var ALast = Li.A.Last as Curve;
					var BBase = Li.B.Base as Curve;
					var BLast = Li.B.Last as Curve;
					var aX = 0.0;
					var aY = 0.0;
					if (IntersectLines(
						ABase.Line.MX, ABase.Line.MY, BLast.Line.EX, BLast.Line.EY,
						ALast.Line.EX, ALast.Line.EY, BBase.Line.MX, BBase.Line.MY,
						ref aX, ref aY)) {
						elseB = new Curve(BBase.Line.MX, BBase.Line.MY, aX, aY);
					} else {
						var CBase = Li.C.Base as Curve;
						var CLast = Li.C.Last as Curve;
						elseB = new Curve(CLast.Line.EX, CLast.Line.EY, BLast.Line.EX, BLast.Line.EY);
					}
				}
				if (Li.ResetA) {
					list.AddLast(Li.A);
				} else {
					if (elseA != null) list.AddLast(elseA);
				}
				if (Li.C.Last != null && (Linear && (IsRoundM || IsRoundE) || (!Linear && IsRoundE && Li.Next == null))) {
					list.AddLast(((Curve)Li.C.Last).Line.HalfArcE(Size));
				}
				if (Li.ResetB) {
					/*if (!Li.ResetA) */
					list.AddLast(Li.B);
				} else {
					if (elseB != null) list.AddLast(elseB);
				}
				for (var I = list.Base as Curve; I != null; I = I.Next as Curve) {
					AddCurve(I.Line);
				}
				Li = Li.Next as Stab;
				if (Li != null) { BeginFz(); }
			}
			End();
		}
		#endregion
		#region #class# Curve 
		public class Curve : Item {
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public Curve() { }
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public Curve(Line Line) {
				this.Line = Line;
			}
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public Curve(double MX, double MY, double EX, double EY) {
				this.Line = new Line(MX, MY, EX, EY);
			}
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public Curve(double MX, double MY, double QX, double QY, double EX, double EY) {
				this.Line = new Quadratic(MX, MY, QX, QY, EX, EY);
			}
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public Curve(double MX, double MY, double cmX, double cmY, double ceX, double ceY, double EX, double EY) {
				this.Line = new Cubic(MX, MY, cmX, cmY, ceX, ceY, EX, EY);
			}
			#region #field# Line 
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.RootHidden)]
#endif
			#endregion
			public Line Line;
			#endregion
			#region #method# ToString 
			public override string ToString() {
				var Line = this.Line;
				var S = "Curve";
				if (Line != null)
					S += " " + Line.ToString();
				return S;
			}
			#endregion
		}
		#endregion
		#region #class# CurveRoot 
		public class CurveRoot : Curve {
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public CurveRoot() { }
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public CurveRoot(Line Line, double Root, double Size) {
				this.Line = Line;
				this.Root = Root;
				this.Size = Size;
			}
			public double Root;
			public double Size;
			#region #method# ToString 
			public override string ToString() {
				var T = System.Globalization.CultureInfo.InvariantCulture;
				var S = "Curve";
				var Root = this.Root;
				var Size = this.Size;
				var Line = this.Line;
				if (!double.IsNaN(Root)) S += " Root = " + Root.ToString("G17", T);
				if (!double.IsNaN(Size)) S += " Size = " + Size.ToString("G17", T);
				if (!double.IsNaN(Root) && !double.IsNaN(Size)) S += " Bound = " + (Root + Size).ToString(T);
				if (Line != null) S += " [" + Line.ToString() + "]";
				return S;
			}
			#endregion
			#region #property# Bound 
			public double Bound {
				#region #through# 
#if TRACE
				[System.Diagnostics.DebuggerStepThrough]
#endif
				#endregion
				get { return this.Root + this.Size; }
			}
			#endregion
		}
		#endregion
		#region #class# Stab 
		public class Stab : Item {
			public double Root;
			public double Size;
			public bool ResetA;
			public bool ResetB;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public readonly List A;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public readonly List B;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.RootHidden)]
#endif
			#endregion
			public readonly List C;
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public Stab(double Root, double Size, bool A = true, bool B = true, bool C = true) {
				if (!A && !B && !C) throw new System.ArgumentOutOfRangeException();
				this.Root = Root;
				this.Size = Size;
				if (A) this.A = new List();
				if (B) this.B = new List();
				if (C) this.C = new List();
			}
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public bool IsUsed {
				#region #through# 
#if TRACE
				[System.Diagnostics.DebuggerStepThrough]
#endif
				#endregion
				get {
					if (this.A != null && this.A.Base != null) return true;
					if (this.B != null && this.B.Base != null) return true;
					if (this.C != null && this.C.Base != null) return true;
					return false;
				}
			}
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public void Add(Line A, Line B, Line C, double Root, double Size) {
				if (this.A != null) this.A.AddLast(new CurveRoot(A, Root, Size));
				if (this.B != null) this.B.AddBase(new CurveRoot(B, Root, Size));
				if (this.C != null) this.C.AddLast(new CurveRoot(C, Root, Size));
			}
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public Stab AddLastTo(List List, bool ResetA, bool ResetB, double ROOT, out double Root, out double Size) {
				var Last = List.Last as Stab;
				var LastRoot = Last.Root;
				var LastSize = Last.Size;
				var PrevSize = LastSize * ROOT;
				LastSize -= PrevSize;
				LastRoot += PrevSize;
				Last.Size = PrevSize;
				var Stab = new Stab(LastRoot, LastSize, this.A != null, this.B != null, this.C != null) { ResetA = ResetA, ResetB = ResetB };
				List.AddLast(Stab);
				Root = LastRoot;
				Size = LastSize;
				return Stab;
			}
		}
		#endregion
		#region #class# Item 
		public class Item {
			#region #field# Prev 
			/// <summary>Предыдущий элемент в списке)</summary>
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Item Prev;
			#endregion
			#region #field# Next 
			/// <summary>Следующий элемент в списке)</summary>
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Item Next;
			#endregion
		}
		#endregion
		#region #class# List 
		public class List {
			#region #field# Base 
			/// <summary>Начинающий элмент в списке)</summary>
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Item Base;
			#endregion
			#region #field# Last 
			/// <summary>Завершающий элмент в списке)</summary>
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Item Last;
			#endregion
			#region #field# Count 
			/// <summary>Количество элементов в списке)</summary>
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public int Count;
			#endregion
			#region #field# Cache 
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			private Item[] Cache;
			#endregion
			#region #method# AddBase(Item) 
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public Item AddBase(Item Item) {
				#region #debug# 
#if DEBUG
				if (Item == null) throw new System.ArgumentNullException();
				if (Item.Prev != null || Item.Next != null) throw new System.ArgumentException();
#endif
				#endregion
				var Base = this.Base;
				Item.Next = Base;
				if (Base == null) { this.Last = Item; } else { Base.Prev = Item; }
				this.Base = Item;
				this.Count++;
				this.Cache = null;
				return Item;
			}
			#endregion
			#region #method# AddLast(Item) 
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public Item AddLast(Item Item) {
				#region #debug# 
#if DEBUG
				if (Item == null) throw new System.ArgumentNullException();
				if (Item.Prev != null || Item.Next != null) throw new System.ArgumentException();
#endif
				#endregion
				var Last = this.Last;
				Item.Prev = Last;
				if (Last == null) { this.Base = Item; } else { Last.Next = Item; }
				this.Last = Item;
				this.Count++;
				this.Cache = null;
				return Item;
			}
			#endregion
			#region #method# AddPrev(Next, Item) 
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public Item AddPrev(Item Next, Item Item) {
				#region #debug# 
#if DEBUG
				if (Next == null) throw new System.ArgumentNullException();
				if (Item == null) throw new System.ArgumentNullException();
				if (Item.Prev != null || Item.Next != null) throw new System.ArgumentException();
#endif
				#endregion
				var Prev = Next.Prev;
				Next.Prev = Item;
				Item.Next = Next;
				Item.Prev = Prev;
				if (Prev != null) { Prev.Next = Item; } else { this.Base = Item; }
				this.Count++;
				this.Cache = null;
				return Item;
			}
			#endregion
			#region #method# AddNext(Prev, Item) 
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public Item AddNext(Item Prev, Item Item) {
				#region #debug# 
#if DEBUG
				if (Prev == null) throw new System.ArgumentNullException();
				if (Item == null) throw new System.ArgumentNullException();
				if (Item.Prev != null || Item.Next != null) throw new System.ArgumentException();
#endif
				#endregion
				var Next = Prev.Next;
				Prev.Next = Item;
				Item.Prev = Prev;
				Item.Next = Next;
				if (Next != null) { Next.Prev = Item; } else { this.Last = Item; }
				this.Count++;
				this.Cache = null;
				return Item;
			}
			#endregion
			#region #method# AddLast(List) 
			public void AddLast(List List) {
				#region #debug# 
#if DEBUG
				if (List == null) throw new System.ArgumentNullException();
				if (List.Base == null || List.Last == null || List.Count == 0) return;
#endif
				#endregion
				if (List != null && List.Base != null) {
					var Last = this.Last;
					this.Last = List.Last;
					if (Last == null) {
						this.Base = List.Base;
						this.Count = List.Count;
					} else {
						(Last.Next = List.Base).Prev = Last;
						this.Count += List.Count;
					}
					List.Base = null;
					List.Last = null;
					List.Count = 0;
					List.Cache = null;
					this.Cache = null;
				}
			}
			#endregion
			#region #method# AddBase(List) 
			public void AddBase(List List) {
				#region #debug# 
#if DEBUG
				if (List == null) throw new System.ArgumentNullException();
				if (List.Base == null || List.Last == null || List.Count == 0) throw new System.ArgumentException();
#endif
				#endregion
				if (List != null && List.Base != null) {
					var Base = this.Base;
					this.Base = List.Base;
					if (Base == null) {
						this.Last = List.Last;
						this.Count = List.Count;
					} else {
						(Base.Prev = List.Base).Next = Base;
						this.Count += List.Count;
					}
					List.Base = null;
					List.Last = null;
					List.Count = 0;
					List.Cache = null;
					this.Cache = null;
				}
			}
			#endregion
			#region #method# AddPrev(Next, List) 
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public void AddPrev(Item Next, List List) {
				#region #debug# 
#if DEBUG
				if (Next == null) throw new System.ArgumentNullException();
				if (List == null) throw new System.ArgumentNullException();
				if (List.Base == null || List.Last == null || List.Count == 0) throw new System.ArgumentException();
#endif
				#endregion
				var Prev = Next.Prev;
				Next.Prev = List.Last;
				List.Last.Next = Next;
				List.Base.Prev = Prev;
				if (Prev != null) { Prev.Next = List.Base; } else { this.Base = List.Last; }
				this.Count += List.Count;
				this.Cache = null;
				List.Count = 0;
				List.Cache = null;
			}
			#endregion
			#region #method# AddNext(Prev, List) 
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public void AddNext(Item Prev, List List) {
				#region #debug# 
#if DEBUG
				if (Prev == null) throw new System.ArgumentNullException();
				if (List == null) throw new System.ArgumentNullException();
				if (List.Base == null || List.Last == null || List.Count == 0) throw new System.ArgumentException();
#endif
				#endregion
				var Next = Prev.Next;
				Prev.Next = List.Base;
				List.Base.Prev = Prev;
				List.Last.Next = Next;
				if (Next != null) { Next.Prev = List.Last; } else { this.Last = List.Base; }
				this.Count += List.Count;
				this.Cache = null;
				List.Count = 0;
				List.Cache = null;
			}
			#endregion
			#region #property# Items 
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.RootHidden)]
#endif
			#endregion
			public Item[] Items {
				#region #through# 
#if TRACE
				[System.Diagnostics.DebuggerStepThrough]
#endif
				#endregion
				get {
					var A = this.Cache;
					if (A == null) {
						var C = this.Count;
						A = new Item[C];
						var I = 0;
						var Item = Base;
						while (Item != null) {
							A[I++] = Item;
							Item = Item.Next;
						}
						this.Cache = A;
					}
					return A;
				}
			}
			#endregion
			#region #method# ToString 
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public override string ToString() {
				var T = System.Globalization.CultureInfo.InvariantCulture;
				return "Count = " + this.Count.ToString(T);
			}
			#endregion
		}
		#endregion
	}
}
