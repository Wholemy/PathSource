namespace Wholemy {
	public class PathSource {
		#region #static# #method#  In(X0, Y0, X1, Y1, X2, Y2) 
		public static bool In(double X0, double Y0, double X1, double Y1, double X2, double Y2) {
			var l01 = Mat.Sqrt(X0 - X1, Y0 - Y1);
			var l02 = Mat.Sqrt(X0 - X2, Y0 - Y2);
			var X = X0 + (X1 - X0) / l01 * l02;
			var Y = Y0 + (Y1 - Y0) / l01 * l02;
			return (X2 - X < 0.000000001 && Y2 - Y < 0.000000001);
		}
		#endregion
		#region #static# #method# Inline(X0, Y0, X1, Y1, X2, Y2) 
		public static bool Inline(double X0, double Y0, double X1, double Y1, double X2, double Y2) {
			if ((X0 < X1 && X1 < X2) || (Y0 < Y1 && Y1 < Y2))
				return In(X0, Y0, X1, Y1, X2, Y2);
			if ((X2 < X1 && X1 < X0) || (Y2 < Y1 && Y1 < Y0))
				return In(X2, Y2, X1, Y1, X0, Y0);
			if ((X1 < X0 && X0 < X2) || (Y1 < Y0 && Y0 < Y2))
				return In(X1, Y1, X0, Y0, X2, Y2);
			if ((X2 < X0 && X0 < X1) || (Y2 < Y0 && Y0 < Y1))
				return In(X2, Y2, X0, Y0, X1, Y1);
			if ((X1 < X2 && X2 < X0) || (Y1 < Y2 && Y2 < Y0))
				return In(X1, Y1, X2, Y2, X0, Y0);
			if ((X0 < X2 && X2 < X1) || (Y0 < Y2 && Y2 < Y1))
				return In(X0, Y0, X2, Y2, X1, Y1);
			return false;
		}
		#endregion
		#region #static# #method# ForDivRoots(Roots) 
		public static double[] ForDivRoots(double[] Roots) {
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
		#region #static# #method# AddRoots 
		public static double[] AddRoots(double A, double B, double C, double[] Roots = null) {
			var D = A - 2.0 * B + C;
			if (D != 0.0) {
				var m1 = -System.Math.Sqrt(B * B - A * C);
				var m2 = -A + B;
				var v1 = -(m1 + m2) / D;
				var v2 = -(-m1 + m2) / D;
				Roots = AddRoots(v1, Roots);
				Roots = AddRoots(v2, Roots);
			} else if (B != C && D == 0.0)
				Roots = AddRoots((2.0 * B - C) / (2.0 * (B - C)), Roots);
			return Roots;
		}
		public static double[] AddRoots(double A, double B, double[] Roots = null) {
			if (A != B) Roots = AddRoots(A / (A - B), Roots);
			return Roots;
		}
		#endregion
		#region #class# Lot 
		public class Lot {
			public int Fl;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public bool Valid;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Lot Pair;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Line Poly;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public int Count;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Dot Base;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Dot Last;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Dot[] Cache;
			#region #new# (Line) 
			public Lot(Line Line) {
				var Poly = this.Poly = Line;
				var Base = this.Base = Poly.Dot(0.0);
				var Last = this.Last = Poly.Dot(1.0);
				Base.Next = Last;
				Last.Prev = Base;
				Base.NextRoot = Last.PrevRoot = 0.5;
				Base.Lot = Last.Lot = this;
				this.Count = 2;
			}
			#endregion
			#region #get# Items 
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.RootHidden)]
#endif
			#endregion
			public Dot[] Items {
				#region #through# 
#if TRACE
				[System.Diagnostics.DebuggerStepThrough]
#endif
				#endregion
				get {
					if (Cache != null) return Cache;
					var I = Count;
					var A = new Dot[I];
					var S = Last;
					while (--I >= 0) { A[I] = S; S = S.Prev; }
					Cache = A;
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
				var I = System.Globalization.CultureInfo.InvariantCulture;
				return "Lot Count:" + Count.ToString();
			}
			#endregion
			#region #method# Adds 
			public void Adds() {
				var I = this.Base;
				var N = true;
				while (I != null) {
					var ii = I.Next;
					if (N) I.AddPrev();
					N = I.AddNext();
					I = ii;
				}
			}
			#endregion
		}
		#endregion
		#region #class# Dot 
		public class Dot {
			public Lot Lot;
			public Dot Prev;
			public Dot Next;
			public double PrevRoot;
			public double NextRoot;
			public double PrevLen;
			public double NextLen;
			/// <summary>Длина до точки другого лота, наиболее короткая)</summary>
			public double Len = double.NaN;
			public readonly double Root;
			public readonly double X;
			public readonly double Y;
			public double AX;
			public double AY;
			public double BX;
			public double BY;
			public double S;
			#region #new# (Root, X, Y, MX, MY, EX, EY) 
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public Dot(double Root, double X, double Y, double AX, double AY, double BX, double BY) {
				this.PrevRoot = this.NextRoot = this.Root = Root;
				this.X = X; this.Y = Y;
				this.AX = AX; this.AY = AY;
				this.BX = BX; this.BY = BY;
				this.S = 0.0;
			}
			#endregion
			#region #method# ToString 
			public override string ToString() {
				var I = System.Globalization.CultureInfo.InvariantCulture;
				return $"Dot Len: {Len.ToString("G17", I)} Root: {Root.ToString("G17", I)} X: {X.ToString("G17", I)} Y: {Y.ToString("G17", I)}";
			}
			#endregion
			#region #method# LenTo(Dot) 
			public double LenTo(Dot Dot) {
				return Mat.Sqrt(this.X - Dot.X, this.Y - Dot.Y);
			}
			#endregion
			#region #method# AddPrev 
			public bool AddPrev() {
				var Lot = this.Lot;
				Dot Prev, New; double Size;
				var R = true;
				if (this.PrevRoot < this.Root) {
					Size = (this.Root - this.PrevRoot) * 0.5;
					New = Lot.Poly.Dot(this.PrevRoot);
					New.PrevRoot -= Size;
					if (New.PrevRoot < 0.0) New.PrevRoot = 0.0;
					New.NextRoot += Size;
					if (New.NextRoot > 1.0) New.NextRoot = 1.0;
					Prev = this.Prev;
					if (Prev != null) {
						if (Prev.NextRoot == this.PrevRoot) {
							Prev.NextRoot = New.PrevRoot;
							R = false;
						}
						New.Prev = Prev;
						Prev.Next = New;
					} else {
						Lot.Base = New;
					}
					this.PrevRoot = New.NextRoot;
					New.Next = this;
					this.Prev = New;
					New.Lot = Lot;
					Lot.Count++;
					Lot.Cache = null;
				}
				return R;
			}
			#endregion
			#region #method# AddNext 
			public bool AddNext() {
				var Lot = this.Lot;
				Dot Next, New; double Size;
				var R = true;
				if (this.NextRoot > this.Root) {
					Size = (this.NextRoot - this.Root) * 0.5;
					New = Lot.Poly.Dot(this.NextRoot);
					New.PrevRoot -= Size;
					if (New.PrevRoot < 0.0)
						New.PrevRoot = 0.0;
					New.NextRoot += Size;
					if (New.NextRoot > 1.0)
						New.NextRoot = 1.0;
					Next = this.Next;
					if (Next != null) {
						if (Next.PrevRoot == this.NextRoot) {
							Next.PrevRoot = New.NextRoot; R = false;
						}
						New.Next = Next;
						Next.Prev = New;
					} else {
						Lot.Last = New;
					}
					this.NextRoot = New.PrevRoot;
					New.Prev = this;
					this.Next = New;
					New.Lot = Lot;
					Lot.Count++;
					Lot.Cache = null;
				}
				return R;
			}
			#endregion
			#region #method# Cut 
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			public void Cut() {
				var Lot = this.Lot;
				if (Lot != null) {
					var P = this.Prev;
					var N = this.Next;
					if (P != null) { P.Next = N; } else { Lot.Base = N; }
					if (N != null) { N.Prev = P; } else { Lot.Last = P; }
					Lot.Count--;
					Lot.Cache = null;
					this.Prev = null; this.Next = null; this.Lot = null;
					this.Len = double.NaN;
					Lot.Pair.Valid = false;
				}
			}
			#endregion
		}
		#endregion
		public static readonly double ArcTan = System.Math.Tan(System.Math.PI / 8);
		public static readonly double Arc14 = 4.0 / 3.0 * System.Math.Tan(System.Math.PI / 8);
		private System.Windows.Media.Geometry HoldPath;
		private System.Windows.Media.GeometryCombineMode HoldMode;
		private System.Windows.Media.Geometry LastPath;
		private System.Windows.Media.GeometryCombineMode LastMode;
		public PathSource() { }
		public System.Windows.Media.Geometry Last => this.LastPath;
		public System.Windows.Media.Geometry Hold => this.HoldPath;
		public double Tolerance = 0.25;
		public System.Windows.Media.ToleranceType ToleranceType = System.Windows.Media.ToleranceType.Absolute;
		public string Final;
		private bool FillRule;
		private bool IsFilled;
		private bool IsClozed;
		private bool Inverted;
		private Preset RootM;
		private Preset RootE;
		#region #class# Preset 
		public class Preset {
			public double Value;
			public Preset(double Value) {
				if (Value < 0 || Value > 1) throw new System.ArgumentOutOfRangeException();
				this.Value = Value;
			}
		}
		#endregion
		#region #method# PresetRoot(Root) 
		public void PresetRoot(double Root) {
			if (Root < 0) {
				this.RootE = new Preset(-Root);
			} else {
				this.RootM = new Preset(Root);
			}
		}
		#endregion
		#region #method# PresetRoot(RootM, RootE) 
		public void PresetRoot(double RootM, double RootE) {
			if (RootM < 0) RootM = -RootM;
			if (RootE < 0) RootE = -RootE;
			this.RootE = new Preset(RootM);
			this.RootM = new Preset(RootE);
		}
		#endregion
		private Change Mod;
		private int FigureCount;
		private Figure FigureBase;
		private Figure FigureLast;
		/// <summary>Толщина линий)</summary>
		public double Thickness;
		public bool IsBonesUse;
		public bool IsRoundM;
		public bool IsRoundE;
		/// <summary>Истинное значение устанавливает точность 0.005 при обнаружении разворотов в кривых,
		/// а так же добавляет излишние операции для нормальной точности, которая эквивалентна значению 0.5)</summary>
		public bool Ideal;
		public const double IdealPrecision = 0.005;
		public const double NormalPrecision = 0.5;
		#region #property# Figures 
		private Figure[] Figures {
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			get {
				var Count = this.FigureCount;
				var Array = new Figure[Count--];
				var Cache = this.FigureLast;
				while (Count >= 0) {
					Array[Count--] = Cache;
					Cache = Cache.Prev;
				}
				return Array;
			}
		}
		#endregion
		#region #method# FiguresToGeometry 
		private System.Windows.Media.Geometry FiguresToGeometry() {
			if (FigureCount > 0) {
				var Stream = new System.Windows.Media.StreamGeometry();
				Stream.FillRule = FillRule ? System.Windows.Media.FillRule.Nonzero : System.Windows.Media.FillRule.EvenOdd;
				var Context = Stream.Open();
				var Figure = FigureBase;
				while (Figure != null) {
					if (Figure.ItemCount > 0) {
						var Cache = Figure.ItemBase;
						var Value = Cache.Value;
						Context.BeginFigure(new System.Windows.Point(Value.MX, Value.MY), Figure.IsFilled, Figure.IsClozed);
						Value.To(Context);
						var PreX = Value.EX;
						var PreY = Value.EY;
						Cache = Cache.Next;
						while (Cache != null) {
							Value = Cache.Value;
							Value.If(Context, PreX, PreY);
							Value.To(Context);
							PreX = Value.EX;
							PreY = Value.EY;
							Cache = Cache.Next;
						}
					}
					Figure = Figure.Next;
				}
				Context.Close();
				return Stream;
			}
			return null;
		}
		#endregion
		#region #method# CombineToGeometry 
		public System.Windows.Media.Geometry CombineToGeometry() {
			var Path = FiguresToGeometry();
			var Prev = this.LastPath;
			if (Prev != null) {
				if (Path != null) {
					Path = System.Windows.Media.Geometry.Combine(Prev, Path, this.LastMode, null, this.Tolerance, this.ToleranceType);
				} else {
					Path = Prev;
				}
				this.LastPath = null;
			}
			var Part = this.HoldPath;
			if (Part != null) {
				if (Path != null) {
					Path = System.Windows.Media.Geometry.Combine(Part, Path, this.HoldMode, null, this.Tolerance, this.ToleranceType);
				} else {
					Path = Part;
				}
				this.HoldPath = null;
			}
			FigureCount = 0;
			FigureBase = null;
			FigureLast = null;
			return Path;
		}
		#endregion
		#region #method# Combine 
		public PathSource Combine() {
			var Path = FiguresToGeometry();
			var Last = this.LastPath;
			if (Last != null) {
				if (Path != null) {
					Path = System.Windows.Media.Geometry.Combine(Last, Path, this.LastMode, null, this.Tolerance, this.ToleranceType);
				} else {
					Path = Last;
				}
				this.LastPath = null;
			}
			var Hold = this.HoldPath;
			if (Hold != null) {
				if (Path != null) {
					Path = System.Windows.Media.Geometry.Combine(Hold, Path, this.HoldMode, null, this.Tolerance, this.ToleranceType);
				} else {
					Path = Hold;
				}
				this.HoldPath = null;
			}
			this.LastPath = Path;
			FigureCount = 0;
			FigureBase = null;
			FigureLast = null;
			return this;
		}
		#endregion
		#region #property# Current 
		public System.Windows.Media.Geometry Current {
			get {
				var Path = FiguresToGeometry();
				var Last = this.LastPath;
				if (Last != null) {
					if (Path != null) {
						Path = System.Windows.Media.Geometry.Combine(Last, Path, this.LastMode, null, this.Tolerance, this.ToleranceType);
					} else {
						Path = Last;
					}
				}
				var Part = this.HoldPath;
				if (Part != null) {
					if (Path != null) {
						Path = System.Windows.Media.Geometry.Combine(Part, Path, this.HoldMode, null, this.Tolerance, this.ToleranceType);
					} else {
						Path = Part;
					}
				}
				return Path;
			}
		}
		#endregion
		#region #method# CombineLast 
		private void CombineLast() {
			var Path = FiguresToGeometry();
			if (Path != null) {
				this.FigureCount = 0;
				this.FigureBase = null;
				this.FigureLast = null;
				this.FillRule = false;
			}
			var Last = this.LastPath;
			if (Last != null) {
				if (Path != null) {
					Path = System.Windows.Media.Geometry.Combine(Last, Path, this.LastMode, null, this.Tolerance, this.ToleranceType);
				} else {
					Path = Last;
				}
			}
			this.LastPath = Path;
		}
		#endregion
		#region #method# CombineHold 
		private void CombineHold() {
			var Path = FiguresToGeometry();
			if (Path != null) {
				this.FigureCount = 0;
				this.FigureBase = null;
				this.FigureLast = null;
				this.FillRule = false;
			}
			var Last = this.LastPath;
			if (Last != null) {
				if (Path != null) {
					Path = System.Windows.Media.Geometry.Combine(Last, Path, this.LastMode, null, this.Tolerance, this.ToleranceType);
				} else {
					Path = Last;
				}
			}
			var Hold = this.HoldPath;
			if (Hold != null) {
				if (Path != null) {
					Path = System.Windows.Media.Geometry.Combine(Hold, Path, this.HoldMode, null, this.Tolerance, this.ToleranceType);
				} else {
					Path = Hold;
				}
			}
			this.HoldPath = Path;
		}
		#endregion
		#region #method# Begin[Part = P][Hollow = H|Filled = F][Closed = z] 
		public void Begin() { new Figure(this); }
		public void BeginHz() { this.IsFilled = false; this.IsClozed = true; new Figure(this); }
		public void BeginH() { this.IsFilled = false; this.IsClozed = false; new Figure(this); }
		public void BeginFz() { this.IsFilled = true; this.IsClozed = true; new Figure(this); }
		public void BeginF() { this.IsFilled = true; this.IsClozed = false; new Figure(this); }
		#endregion
		#region #method# Union[Part = P][Hollow = H|Filled = F][Closed = z] 
		public void Union() { this.CombineLast(); this.LastMode = System.Windows.Media.GeometryCombineMode.Union; }
		public void UnionHz() { this.IsFilled = false; this.IsClozed = true; this.Union(); }
		public void UnionH() { this.IsFilled = false; this.IsClozed = false; this.Union(); }
		public void UnionFz() { this.IsFilled = true; this.IsClozed = true; this.Union(); }
		public void UnionF() { this.IsFilled = true; this.IsClozed = false; this.Union(); }
		public void UnionP() { this.CombineHold(); this.HoldMode = System.Windows.Media.GeometryCombineMode.Union; }
		public void UnionPHz() { this.IsFilled = false; this.IsClozed = true; this.UnionP(); }
		public void UnionPH() { this.IsFilled = false; this.IsClozed = false; this.UnionP(); }
		public void UnionPFz() { this.IsFilled = true; this.IsClozed = true; this.UnionP(); }
		public void UnionPF() { this.IsFilled = true; this.IsClozed = false; this.UnionP(); }
		#endregion
		#region #method# Intersect[Part = P][Hollow = H|Filled = F][Closed = z] 
		public void Intersect() { this.CombineLast(); this.LastMode = System.Windows.Media.GeometryCombineMode.Intersect; }
		public void IntersectHz() { this.IsFilled = false; this.IsClozed = true; this.Intersect(); }
		public void IntersectH() { this.IsFilled = false; this.IsClozed = false; this.Intersect(); }
		public void IntersectFz() { this.IsFilled = true; this.IsClozed = true; this.Intersect(); }
		public void IntersectF() { this.IsFilled = true; this.IsClozed = false; this.Intersect(); }
		public void IntersectP() { this.CombineHold(); this.HoldMode = System.Windows.Media.GeometryCombineMode.Intersect; }
		public void IntersectPHz() { this.IsFilled = false; this.IsClozed = true; this.IntersectP(); }
		public void IntersectPH() { this.IsFilled = false; this.IsClozed = false; this.IntersectP(); }
		public void IntersectPFz() { this.IsFilled = true; this.IsClozed = true; this.IntersectP(); }
		public void IntersectPF() { this.IsFilled = true; this.IsClozed = false; this.IntersectP(); }
		#endregion
		#region #method# Xor[Part = P][Hollow = H|Filled = F][Closed = z] 
		public void Xor() { this.CombineLast(); this.LastMode = System.Windows.Media.GeometryCombineMode.Xor; }
		public void XorHz() { this.IsFilled = false; this.IsClozed = true; this.Xor(); }
		public void XorH() { this.IsFilled = false; this.IsClozed = false; this.Xor(); }
		public void XorFz() { this.IsFilled = true; this.IsClozed = true; this.Xor(); }
		public void XorF() { this.IsFilled = true; this.IsClozed = false; this.Xor(); }
		public void XorP() { this.CombineHold(); this.HoldMode = System.Windows.Media.GeometryCombineMode.Xor; }
		public void XorPHz() { this.IsFilled = false; this.IsClozed = true; this.XorP(); }
		public void XorPH() { this.IsFilled = false; this.IsClozed = false; this.XorP(); }
		public void XorPFz() { this.IsFilled = true; this.IsClozed = true; this.XorP(); }
		public void XorPF() { this.IsFilled = true; this.IsClozed = false; this.XorP(); }
		#endregion
		#region #method# Exclude[Part = P][Hollow = H|Filled = F][Closed = z] 
		public void Exclude() { this.CombineLast(); this.LastMode = System.Windows.Media.GeometryCombineMode.Exclude; }
		public void ExcludeHz() { this.IsFilled = false; this.IsClozed = true; this.Exclude(); }
		public void ExcludeH() { this.IsFilled = false; this.IsClozed = false; this.Exclude(); }
		public void ExcludeFz() { this.IsFilled = true; this.IsClozed = true; this.Exclude(); }
		public void ExcludeF() { this.IsFilled = true; this.IsClozed = false; this.Exclude(); }
		public void ExcludeP() { this.CombineHold(); this.HoldMode = System.Windows.Media.GeometryCombineMode.Exclude; }
		public void ExcludePHz() { this.IsFilled = false; this.IsClozed = true; this.ExcludeP(); }
		public void ExcludePH() { this.IsFilled = false; this.IsClozed = false; this.ExcludeP(); }
		public void ExcludePFz() { this.IsFilled = true; this.IsClozed = true; this.ExcludeP(); }
		public void ExcludePF() { this.IsFilled = true; this.IsClozed = false; this.ExcludeP(); }
		#endregion
		#region #method# AddItem(Val) 
		public Item AddItem(Line Val) {
			var Fig = this.FigureLast ?? new Figure(this);
			Val.Change(this.Mod, (this.Inverted && Fig.Inverted));
			return new Item(Fig, Val);
		}
		#endregion
		#region #method# AddItem(MX, MY, EX, EY) 
		public Item AddItem(double MX, double MY, double EX, double EY) {
			return AddItem(new Line(MX, MY, EX, EY));
		}
		#endregion
		#region #method# AddItem(Val) 
		public Item AddItem(Quadratic Val) {
			var Fig = this.FigureLast ?? new Figure(this);
			Val.Change(this.Mod, (this.Inverted && Fig.Inverted));
			return new Item(Fig, Val);
		}
		#endregion
		#region #method# AddItem(MX, MY, QX, QY, EX, EY) 
		public Item AddItem(double MX, double MY, double QX, double QY, double EX, double EY) {
			return AddItem(new Quadratic(MX, MY, QX, QY, EX, EY));
		}
		#endregion
		#region #method# AddItem(Val) 
		public Item AddItem(Cubic Val) {
			var Fig = this.FigureLast ?? new Figure(this);
			Val.Change(this.Mod, (this.Inverted && Fig.Inverted));
			return new Item(Fig, Val);
		}
		#endregion
		#region #method# AddItem(MX, MY, cmX, cmY, ceX, ceY, EX, EY) 
		public Item AddItem(double MX, double MY, double cmX, double cmY, double ceX, double ceY, double EX, double EY) {
			return AddItem(new Cubic(MX, MY, cmX, cmY, ceX, ceY, EX, EY));
		}
		#endregion
		#region #method# AddBone(Val) 
		public Bone AddBone(Line Val) {
			var Fig = this.FigureLast ?? new Figure(this);
			if (this.Inverted && Fig.Inverted) Val.Invert();
			return new Bone(Fig, Val);
		}
		#endregion
		#region #method# AddBone(MX, MY, EX, EY) 
		public Bone AddBone(double MX, double MY, double EX, double EY) {
			return AddBone(new Line(MX, MY, EX, EY));
		}
		#endregion
		#region #method# AddBone(Val) 
		public Bone AddBone(Quadratic Val) {
			var Fig = this.FigureLast ?? new Figure(this);
			if (this.Inverted && Fig.Inverted) Val.Invert();
			return new Bone(Fig, Val);
		}
		#endregion
		#region #method# AddBone(MX, MY, QX, QY, EX, EY) 
		public Bone AddBone(double MX, double MY, double QX, double QY, double EX, double EY) {
			return AddBone(new Quadratic(MX, MY, QX, QY, EX, EY));
		}
		#endregion
		#region #method# AddBone(Val) 
		public Bone AddBone(Cubic Val) {
			var Fig = this.FigureLast ?? new Figure(this);
			if (this.Inverted && Fig.Inverted) Val.Invert();
			return new Bone(Fig, Val);
		}
		#endregion
		#region #method# AddBone(MX, MY, cmX, cmY, ceX, ceY, EX, EY) 
		public Bone AddBone(double MX, double MY, double cmX, double cmY, double ceX, double ceY, double EX, double EY) {
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
				this.AR = AR = Mat.GetAR(CX, CY, BX, BY, AX, AY);
				this.CX = CX;
				this.CY = CY;
			}
			public override void Modify(ref double X, ref double Y, bool x, bool y) {
				if (x || y) {
					var AX = X;
					var AY = Y;
					Mat.Rotate(this.CX, this.CY, ref AX, ref AY, this.AR);
					if (x) X = AX;
					if (y) Y = AY;
				}
			}
		}
		public class RotAsMod : Change {
			public double A, CX, CY;
			public RotAsMod(Change Next, double A, double CX, double CY, Mods Mods = Mods.All) : base(Next, Mods) {
				this.A = A;
				this.CX = CX;
				this.CY = CY;
			}
			public override void Modify(ref double X, ref double Y, bool x, bool y) {
				if (x || y) {
					var RX = X;
					var RY = Y;
					var A = this.A;
					var CX = this.CX;
					var CY = this.CY;
					A = A * System.Math.PI / 180.0;
					var AC = System.Math.Cos(A);
					var AS = System.Math.Sin(A);
					RX -= CX;
					RY -= CY;
					if (x) X = ((RX * AC) - (RY * AS)) + CX;
					if (y) Y = ((RX * AS) + (RY * AC)) + CY;
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
					var RX = X;
					var RY = Y;
					var AX = this.AX;
					var AY = this.AY;
					var CX = this.CX;
					var CY = this.CY;
					double A;
					if (((CX < AX && CY < AY) || (CX > AX && CY > AY)) ^ CW) {
						A = (AY > CY ? AY - CY : CY - AY) / (AX > CX ? CX - AX : AX - CX);
					} else {
						A = (AX > CX ? CX - AX : AX - CX) / (AY > CY ? AY - CY : CY - AY);
					}
					if (!CW) A = -A;
					A = System.Math.Atan(A);
					var AC = System.Math.Cos(A);
					var AS = System.Math.Sin(A);
					RX -= CX;
					RY -= CY;
					if (x) X = ((RX * AC) - (RY * AS)) + CX;
					if (y) Y = ((RX * AS) + (RY * AC)) + CY;
				}
			}
		}
		#endregion
		#region #class# Figure 
		public class Figure {
			public bool IsFilled;
			public bool IsClozed;
			public bool Inverted;
			public PathSource Owner;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Figure Prev;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Figure Next;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public int ItemCount;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Item ItemBase;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Item ItemLast;
			#region #property# Items 
			public Line[] Items {
				#region #through# 
#if TRACE
				[System.Diagnostics.DebuggerStepThrough]
#endif
				#endregion
				get {
					var Count = this.ItemCount;
					var Array = new Line[Count--];
					var Item = this.ItemLast;
					while (Count >= 0) {
						Array[Count--] = Item.Value;
						Item = Item.Prev;
					}
					return Array;
				}
			}
			#endregion
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public int BoneCount;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Bone BoneBase;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Bone BoneLast;
			#region #property# Bones 
			public Line[] Bones {
				#region #through# 
#if TRACE
				[System.Diagnostics.DebuggerStepThrough]
#endif
				#endregion
				get {
					var Count = this.BoneCount;
					var Array = new Line[Count--];
					var Bone = this.BoneLast;
					while (Count >= 0) {
						Array[Count--] = Bone.Value;
						Bone = Bone.Prev;
					}
					return Array;
				}
			}
			#endregion
			#region #new# (Owner) 
			public Figure(PathSource Owner) {
				this.IsFilled = Owner.IsFilled;
				this.IsClozed = Owner.IsClozed;
				this.Inverted = Owner.Inverted;
				this.Owner = Owner;
				if (Owner.FigureCount == 0) {
					Owner.FigureCount = 1;
					Owner.FigureBase = this;
					Owner.FigureLast = this;
				} else {
					(this.Prev = Owner.FigureLast).Next = this;
					Owner.FigureLast = this;
					Owner.FigureCount++;
				}
			}
			#endregion
			#region #method# ToString 
			public override string ToString() {
				var I = System.Globalization.CultureInfo.InvariantCulture;
				var S = "";
				if (ItemCount > 0) {
					var Cache = ItemBase;
					S = "M" + Cache.Value.MX.ToString(I) + "," + Cache.Value.MY.ToString(I);
					while (Cache != null) {
						S += Cache.Value.ToPathString();
						Cache = Cache.Next;
					}
				}
				if (IsClozed) S += "z";
				return S;
			}
			#endregion
		}
		#endregion
		#region #class# Bone 
		public class Bone {
			public Figure Figure;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Bone Prev;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Bone Next;
			public Line Value;
			#region #new# (Figure, Value) 
			public Bone(Figure Figure, Line Value) {
				this.Figure = Figure;
				this.Value = Value;
				if (Figure.BoneCount == 0) {
					Figure.BoneCount = 1;
					Figure.BoneBase = this;
					Figure.BoneLast = this;
				} else {
					if (Figure.Inverted) {
						(this.Next = Figure.BoneBase).Prev = this;
						Figure.BoneBase = this;
					} else {
						(this.Prev = Figure.BoneLast).Next = this;
						Figure.BoneLast = this;
					}
					Figure.BoneCount++;
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
				return Value.ToString();
			}
			#endregion
		}
		#endregion
		#region #class# Item 
		public class Item {
			public Figure Figure;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Item Prev;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Item Next;
			public Line Value;
			#region #new# (Figure, Value) 
			public Item(Figure Figure, Line Value) {
				this.Figure = Figure;
				this.Value = Value;
				if (Figure.ItemCount == 0) {
					Figure.ItemCount = 1;
					Figure.ItemBase = this;
					Figure.ItemLast = this;
				} else {
					if (Figure.Inverted) {
						(this.Next = Figure.ItemBase).Prev = this;
						Figure.ItemBase = this;
					} else {
						(this.Prev = Figure.ItemLast).Next = this;
						Figure.ItemLast = this;
					}
					Figure.ItemCount++;
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
				return Value.ToString();
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
			#region #method# Change(Mod, Invert) 
			public virtual void Change(Change Mod, bool Invert = false) {
				var MX = this.MX; var MY = this.MY; var EX = this.EX; var EY = this.EY;
				while (Mod != null) {
					Mod.Modify(ref MX, ref MY, (Mod.Mods & Mods.MX) != 0, (Mod.Mods & Mods.MY) != 0);
					Mod.Modify(ref EX, ref EY, (Mod.Mods & Mods.EX) != 0, (Mod.Mods & Mods.EY) != 0);
					Mod = Mod.Next;
				}
				if (Invert) {
					this.MX = EX; this.MY = EY; this.EX = MX; this.EY = MY;
				} else {
					this.MX = MX; this.MY = MY; this.EX = EX; this.EY = EY;
				}
			}
			#endregion
			#region #method# If(Context, X, Y) 
			public virtual void If(System.Windows.Media.StreamGeometryContext Context, double X, double Y) {
				if (!double.Equals(X, MX) || !double.Equals(Y, MY))
					Context.LineTo(new System.Windows.Point(MX, MY), true, true);
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
			#region #method# AddArcM(P) 
			public virtual void AddArcM(PathSource P) {
				var S = P.Thickness / 2;
				var A = S * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var EX = this.EX;
				var EY = this.EY;
				var meL = Mat.Sqrt(MX - EX, MY - EY);
				var YX = (EY - MY) / meL * S;
				var XY = (MX - EX) / meL * S;
				var AX = MX + YX;
				var AY = MY + XY;
				var BX = MX - YX;
				var BY = MY - XY;
				var CX = MX + (MX - EX) / meL * S;
				var CY = MY + (MY - EY) / meL * S;
				new Cubic(BX, BY, (BX + (MY - BY) / S * A), (BY + (BX - MX) / S * A), (CX + (CY - MY) / S * A), (CY + (MX - CX) / S * A), CX, CY).DivArc(out var a0, out var a1);
				new Cubic(CX, CY, (CX + (MY - CY) / S * A), (CY + (CX - MX) / S * A), (AX + (AY - MY) / S * A), (AY + (MX - AX) / S * A), AX, AY).DivArc(out var a2, out var a3);
				P.AddItem(a0);
				P.AddItem(a1);
				P.AddItem(a2);
				P.AddItem(a3);
			}
			#endregion
			#region #method# AddArcE(P) 
			public virtual void AddArcE(PathSource P) {
				var S = P.Thickness / 2;
				var A = S * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var EX = this.EX;
				var EY = this.EY;
				var meL = Mat.Sqrt(MX - EX, MY - EY);
				var YX = (EY - MY) / meL * S;
				var XY = (MX - EX) / meL * S;
				var AX = EX + YX;
				var AY = EY + XY;
				var BX = EX - YX;
				var BY = EY - XY;
				var CX = EX + (EX - MX) / meL * S;
				var CY = EY + (EY - MY) / meL * S;
				new Cubic(AX, AY, (AX + (EY - AY) / S * A), (AY + (AX - EX) / S * A), (CX + (CY - EY) / S * A), (CY + (EX - CX) / S * A), CX, CY).DivArc(out var a0, out var a1);
				new Cubic(CX, CY, (CX + (EY - CY) / S * A), (CY + (CX - EX) / S * A), (BX + (BY - EY) / S * A), (BY + (EX - BX) / S * A), BX, BY).DivArc(out var a2, out var a3);
				P.AddItem(a0);
				P.AddItem(a1);
				P.AddItem(a2);
				P.AddItem(a3);
			}
			#endregion
			#region #method# AddLinM(P) 
			public virtual void AddLinM(PathSource P) {
				var S = P.Thickness / 2;
				var A = S * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var EX = this.EX;
				var EY = this.EY;
				var meL = Mat.Sqrt(MX - EX, MY - EY);
				var YX = (EY - MY) / meL * S;
				var XY = (MX - EX) / meL * S;
				var AX = MX + YX;
				var AY = MY + XY;
				var BX = MX - YX;
				var BY = MY - XY;
				P.AddItem(new Line(BX, BY, AX, AY));
			}
			#endregion
			#region #method# AddLinE(P) 
			public virtual void AddLinE(PathSource P) {
				var S = P.Thickness / 2;
				var A = S * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var EX = this.EX;
				var EY = this.EY;
				var meL = Mat.Sqrt(MX - EX, MY - EY);
				var YX = (EY - MY) / meL * S;
				var XY = (MX - EX) / meL * S;
				var AX = EX + YX;
				var AY = EY + XY;
				var BX = EX - YX;
				var BY = EY - XY;
				P.AddItem(new Line(AX, AY, BX, BY));
			}
			#endregion
			#region #method# Dot(root) 
			public virtual Dot Dot(double root) {
				if (root < 0.0 || root > 1.0) throw new System.InvalidOperationException();
				var R = root;
				var x00 = MX;
				var y00 = MY;
				var x11 = EX;
				var y11 = EY;
				var x01 = (x11 - x00) * R + x00;
				var y01 = (y11 - y00) * R + y00;
				return new Dot(root, x01, y01, x00, y00, x11, y11);
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
			#region #method# DivArc(A, B) 
			public void DivArc(out Cubic A, out Cubic B) {
				var x00 = MX;
				var y00 = MY;
				var x11 = cmX;
				var y11 = cmY;
				var x22 = ceX;
				var y22 = ceY;
				var x33 = EX;
				var y33 = EY;
				var x01 = (x11 - x00) * 0.5 + x00;
				var y01 = (y11 - y00) * 0.5 + y00;
				var x12 = (x22 - x11) * 0.5 + x11;
				var y12 = (y22 - y11) * 0.5 + y11;
				var x23 = (x33 - x22) * 0.5 + x22;
				var y23 = (y33 - y22) * 0.5 + y22;
				var x02 = (x12 - x01) * 0.5 + x01;
				var y02 = (y12 - y01) * 0.5 + y01;
				var x13 = (x23 - x12) * 0.5 + x12;
				var y13 = (y23 - y12) * 0.5 + y12;
				var x03 = (x13 - x02) * 0.5 + x02;
				var y03 = (y13 - y02) * 0.5 + y02;
				double X, Y;
				var al0 = System.Math.Sqrt((X = x23 - x33) * X + (Y = y23 - y33) * Y);
				var bl0 = System.Math.Sqrt((X = x01 - x00) * X + (Y = y01 - y00) * Y);
				var al1 = System.Math.Sqrt((X = x03 - x13) * X + (Y = y03 - y13) * Y);
				var bl1 = System.Math.Sqrt((X = x02 - x03) * X + (Y = y02 - y03) * Y);
				var al2 = al1 + (al0 - al1) * 0.5;
				var bl2 = bl1 + (bl0 - bl1) * 0.5;
				var x23u = x33 + (x23 - x33) / al0 * al2;
				var y23u = y33 + (y23 - y33) / al0 * al2;
				var x01u = x00 + (x01 - x00) / bl0 * bl2;
				var y01u = y00 + (y01 - y00) / bl0 * bl2;
				var x13u = x03 + (x13 - x03) / al1 * al2;
				var y13u = y03 + (y13 - y03) / al1 * al2;
				var x02u = x03 + (x02 - x03) / bl1 * bl2;
				var y02u = y03 + (y02 - y03) / bl1 * bl2;
				A = new Cubic(x00, y00, x01u, y01u, x02u, y02u, x03, y03);
				B = new Cubic(x03, y03, x13u, y13u, x23u, y23u, x33, y33);
			}
			#endregion
			#region #method# Div(R, A, B) 
			public void Div(double R, out Cubic A, out Cubic B) {
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
			#region #method# Dot(root) 
			public override Dot Dot(double R) {
				if (R < 0.0 || R > 1.0) throw new System.InvalidOperationException();
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
				var x02 = (x12 - x01) * R + x01;
				var y02 = (y12 - y01) * R + y01;
				var x23 = (x33 - x22) * R + x22;
				var y23 = (y33 - y22) * R + y22;
				var x13 = (x23 - x12) * R + x12;
				var y13 = (y23 - y12) * R + y12;
				var x03 = (x13 - x02) * R + x02;
				var y03 = (y13 - y02) * R + y02;
				return new Dot(R, x03, y03, x13, y13, x02, y02);
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
			#region #method# Change(Mod, Invert) 
			public override void Change(Change Mod, bool Invert) {
				var MX = this.MX; var MY = this.MY; var cmX = this.cmX; var cmY = this.cmY; var ceX = this.ceX; var ceY = this.ceY; var EX = this.EX; var EY = this.EY;
				while (Mod != null) {
					Mod.Modify(ref MX, ref MY, (Mod.Mods & Mods.MX) != 0, (Mod.Mods & Mods.MY) != 0);
					Mod.Modify(ref EX, ref EY, (Mod.Mods & Mods.EX) != 0, (Mod.Mods & Mods.EY) != 0);
					Mod.Modify(ref cmX, ref cmY, (Mod.Mods & Mods.cmX) != 0, (Mod.Mods & Mods.cmY) != 0);
					Mod.Modify(ref ceX, ref ceY, (Mod.Mods & Mods.ceX) != 0, (Mod.Mods & Mods.ceY) != 0);
					Mod = Mod.Next;
				}
				if (Invert) {
					this.MX = EX; this.MY = EY; this.cmX = ceX; this.cmY = ceY; this.ceX = cmX; this.ceY = cmY; this.EX = MX; this.EY = MY;
				} else {
					this.MX = MX; this.MY = MY; this.cmX = cmX; this.cmY = cmY; this.ceX = ceX; this.ceY = ceY; this.EX = EX; this.EY = EY;
				}
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
			#region #method# AddArcM(P) 
			public override void AddArcM(PathSource P) {
				var Size = P.Thickness / 2;
				var A = Size * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var cmX = this.cmX;
				var cmY = this.cmY;
				var ceX = this.ceX;
				var ceY = this.ceY;
				var EX = this.EX;
				var EY = this.EY;
				var cmL = Mat.Sqrt(MX - cmX, MY - cmY);
				var ceL = Mat.Sqrt(EX - ceX, EY - ceY);
				var meL = Mat.Sqrt(MX - EX, MY - EY);
				if (cmL > 0.0) {
					if (Mat.Sqrt(EX - cmX, EY - cmY) > 0.0) {
						EX = cmX;
						EY = cmY;
						meL = cmL;
					}
				} else if (ceL > 0.0) {
					if (Mat.Sqrt(MX - ceX, MY - ceY) > 0.0) {
						EX = ceX;
						EY = ceY;
						meL = Mat.Sqrt(MX - EX, MY - EY);
					}
				}
				var YX = (EY - MY) / meL * Size;
				var XY = (MX - EX) / meL * Size;
				var AX = MX + YX;
				var AY = MY + XY;
				var BX = MX - YX;
				var BY = MY - XY;
				var CX = MX + (MX - EX) / meL * Size;
				var CY = MY + (MY - EY) / meL * Size;
				var a = new Cubic(BX, BY, (BX + (MY - BY) / Size * A), (BY + (BX - MX) / Size * A), (CX + (CY - MY) / Size * A), (CY + (MX - CX) / Size * A), CX, CY);
				var b = new Cubic(CX, CY, (CX + (MY - CY) / Size * A), (CY + (CX - MX) / Size * A), (AX + (AY - MY) / Size * A), (AY + (MX - AX) / Size * A), AX, AY);
				P.AddItem(a);
				P.AddItem(b);
			}
			#endregion
			#region #method# NormalAddA(P) 
			public bool NormalAddA(PathSource P) {
				var Size = P.Thickness / 2.0;
				var S = 0.05 * Size;
				if (S < 0.0005) S = 0.0005; else if (S > 0.5) S = 0.5;
				var DIV = 0.5;
				var TES = this;
				Cubic NOW;
				Cubic RAM;
				
				Cubic SET = null;
				DIV = 0.5;
				NEXT:
				if (TES.ExtA(S, Size, ref SET)) {
					P.AddItem(SET);
				} else {
					LESS:
					TES.Div(DIV, out NOW, out RAM);
					if (NOW.ExtA(S, Size, ref SET)) {
						P.AddItem(SET);
						TES = RAM;
						DIV = 0.5;
						goto NEXT;
					} else {
						DIV /= 2.0;
						if (DIV > 0) goto LESS;
					}
				}
				return false;
			}
			#endregion
			#region #method# NormalAddB(P) 
			public bool NormalAddB(PathSource P) {
				//return NorAddB(P);
				var Size = P.Thickness / 2.0;
				var S = 0.05 * Size;
				if (S < 0.0005) S = 0.0005; else if (S > 0.5) S = 0.5;
				var TES = this;
				var DIV = 0.5;
				Cubic NOW;
				Cubic RAM;
				Cubic SET = null;
				NEXT:
				if (TES.ExtB(S, Size, ref SET)) {
					P.AddItem(SET);
				} else {
					LESS:
					TES.Div(1.0 - DIV, out RAM, out NOW);
					if (NOW.ExtB(S, Size, ref SET)) {
						P.AddItem(SET);
						TES = RAM;
						DIV = 0.5;
						goto NEXT;
					} else {
						DIV /= 2.0;
						if (DIV > 0) goto LESS;
					}
				}
				return false;
			}
			#endregion
			#region #method# ExtA(Need, Size, Result) 
			public bool ExtA(double Need, double Size, ref Cubic Result) {
				if (this.Ext(Size, out var Item)) {
					this.Div(0.5, out var BA, out var BB);
					Item.Div(0.5, out var AA, out var AB);
					if (BB.Ext(Size, out var B)) {
						var cmcL = Mat.Sqrt(AB.MX - B.MX, AB.MY - B.MY);
						if (cmcL < Need) {
							Result = Item;
							return true;
						}
					}
				}
				return false;
			}
			#endregion
			#region #method# ExtB(Need, Size, Result) 
			public bool ExtB(double Need, double Size, ref Cubic Result) {
				if (this.Ext(Size, out var Item, true)) {
					this.Div(0.5, out var RA, out var RB);
					Item.Div(0.5, out var BA, out var BB);
					if (RB.Ext(Size, out var B, true)) {
						var cecL = Mat.Sqrt(BA.EX - B.EX, BA.EY - B.EY);
						if (cecL < Need) {
							Result = Item;
							return true;
						}
					}
				}
				return false;
			}
			#endregion
			#region #method# IdealAddA(P) 
			public bool IdealAddA(PathSource P) {
				var Size = P.Thickness / 2.0;
				var S = 0.005 * Size;
				if (S < 0.0005) S = 0.0005; else if (S > 0.5) S = 0.5;
				var DIV = 0.5;
				var TES = this;
				Cubic NOW;
				Cubic RAM;
				Cubic PRENOW;
				Cubic PRERAM;
				var PREDIV = 0.0;
				Cubic PRESET = null;
				Cubic PRETES = null;
				Cubic SET = null;
				Cubic NEWSET = null;
				DIV = 0.5;
				NEXT:
				if (TES.ExtA(S, Size, ref SET)) {
					if (PRETES != null)
						P.AddItem(PRESET);
					P.AddItem(SET);
				} else {
					LESS:
					TES.Div(DIV, out NOW, out RAM);
					if (NOW.ExtA(S, Size, ref SET)) {
						if (PRETES != null) {
							var NEWDIV = PREDIV + (1.0 - PREDIV) * DIV;
							PRETES.Div(NEWDIV, out PRENOW, out PRERAM);
							if (PRENOW.ExtA(S, Size, ref NEWSET)) {
								PREDIV = NEWDIV;
								PRESET = NEWSET;
							} else {
								P.AddItem(PRESET);
								PRETES = TES;
								PREDIV = DIV;
								PRESET = SET;
							}
						} else {
							PRETES = TES;
							PREDIV = DIV;
							PRESET = SET;
						}
						TES = RAM;
						DIV = 0.5;
						goto NEXT;
					} else {
						DIV /= 2.0;
						if (DIV > 0) goto LESS;
					}
				}
				return false;
			}
			#endregion
			#region #method# IdealAddB(P) 
			public bool IdealAddB(PathSource P) {
				var Size = P.Thickness / 2.0;
				var S = 0.005 * Size;
				if (S < 0.0005) S = 0.0005; else if (S > 0.5) S = 0.5;
				var TES = this;
				var DIV = 0.5;
				Cubic NOW;
				Cubic RAM;
				Cubic PRENOW;
				Cubic PRERAM;
				var PREDIV = 0.0;
				Cubic PRESET = null;
				Cubic PRETES = null;
				Cubic SET = null;
				Cubic NEWSET = null;
				NEXT:
				if (TES.ExtB(S, Size, ref SET)) {
					if (PRETES != null)
						P.AddItem(PRESET);
					P.AddItem(SET);
				} else {
					LESS:
					TES.Div(1.0 - DIV, out RAM, out NOW);
					if (NOW.ExtB(S, Size, ref SET)) {
						if (PRETES != null) {
							var NEWDIV = PREDIV + (1.0 - PREDIV) * DIV;
							PRETES.Div(1.0 - NEWDIV, out PRERAM, out PRENOW);
							if (PRENOW.ExtB(S, Size, ref NEWSET)) {
								PREDIV = NEWDIV;
								PRESET = NEWSET;
							} else {
								P.AddItem(PRESET);
								PRETES = TES;
								PREDIV = DIV;
								PRESET = SET;
							}
						} else {
							PRETES = TES;
							PREDIV = DIV;
							PRESET = SET;
						}
						TES = RAM;
						DIV = 0.5;
						goto NEXT;
					} else {
						DIV /= 2.0;
						if (DIV > 0) goto LESS;
					}
				}
				return false;
			}
			#endregion
			#region #method# Ext(S, A, B) 
			/// <summary>Расширяет кривую на указанную толщину)</summary>
			/// <param name="S">Толщина линии, положительное или отридцательное значение определяет сторону)</param>
			/// <param name="A">Возвращаемая кривая, если длина исходной кривой больше нуля)</param>
			/// <param name="B">Инвертированная кривая с другой стороны, если длина исходной кривой больше нуля)</param>
			/// <returns>Успех если длина исходной кривой больше нуля)</returns>
			public bool Ext(double S, out Cubic A, out Cubic B) {
				var MX = this.MX;
				var MY = this.MY;
				var cmX = this.cmX;
				var cmY = this.cmY;
				var ceX = this.ceX;
				var ceY = this.ceY;
				var EX = this.EX;
				var EY = this.EY;
				var l0 = Mat.Path(cmX - MX, cmY - MY, out var l0X, out var l0Y);
				var l1 = Mat.Path(ceX - cmX, ceY - cmY, out var l1X, out var l1Y);
				var l2 = Mat.Path(EX - ceX, EY - ceY, out var l2X, out var l2Y);
				//var l = l0 + l1 + l2;
				//if (l == 0.0) { A = null; B = null; return false; }
				if (l0 == 0.0) if (l1 > 0.0) { l0X = l1X; l0Y = l1Y; } else { l0X = l2X; l0Y = l2Y; }
				if (l2 == 0.0) if (l1 > 0.0) { l2X = l1X; l2Y = l1Y; } else { l2X = l0X; l2Y = l0Y; }
				A = new Cubic(MX + S * l0X, MY + S * l0Y, cmX + S * l1X, cmY + S * l1Y, ceX + S * l1X, ceY + S * l1Y, EX + S * l2X, EY + S * l2Y);
				S = -S;
				B = new Cubic(EX + S * l2X, EY + S * l2Y, ceX + S * l1X, ceY + S * l1Y, cmX + S * l1X, cmY + S * l1Y, MX + S * l0X, MY + S * l0Y);
				return true;
			}
			#endregion
			#region #method# Ext(S, R, I) 
			/// <summary>Расширяет кривую на указанную толщину)</summary>
			/// <param name="S">Толщина линии, положительное или отридцательное значение определяет сторону)</param>
			/// <param name="R">Возвращаемая кривая, если длина исходной кривой больше нуля)</param>
			/// <param name="I">Истина инвертирует значение толщины и направление возвращаемой кривой)</param>
			/// <returns>Успех если длина исходной кривой больше нуля)</returns>
			public bool Ext(double S, out Cubic R, bool I = false) {
				var MX = this.MX;
				var MY = this.MY;
				var cmX = this.cmX;
				var cmY = this.cmY;
				var ceX = this.ceX;
				var ceY = this.ceY;
				var EX = this.EX;
				var EY = this.EY;
				var l0 = Mat.Path(cmX - MX, cmY - MY, out var l0X, out var l0Y);
				var l1 = Mat.Path(ceX - cmX, ceY - cmY, out var l1X, out var l1Y);
				var l2 = Mat.Path(EX - ceX, EY - ceY, out var l2X, out var l2Y);
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
			#region #method# TesReturn(Size, PA, PB, Reset) 
			public bool TesReturn(double Size, ref Cubic PA, ref Cubic PB, out bool Reset) {
				Reset = false;
				var S = 0.05 * Size;
				if (S < 0.005) S = 0.005; //else if (S > 0.5) S = 0.5;
				if (this.Ext(Size, out var A, out var B)) {
					this.Div(0.5, out var RA, out var T);
					if (T.Ext(Size, out var TA, out var TB)) {
						A.Div(0.5, out var AA, out var AB);
						B.Div(0.5, out var BA, out var BB);
						var AL = Mat.Sqrt(AB.MX - TA.MX, AB.MY - TA.MY);
						var BL = Mat.Sqrt(BA.EX - TB.EX, BA.EY - TB.EY);
						if (AL < S && BL < S) {
							if (PA != null && PB != null) {
								var Aa = Mat.GetA1(PA.EX, PA.EY, PA.MX, PA.MY, A.EX, A.EY);
								var Bb = Mat.GetA1(PB.MX, PB.MY, PB.EX, PB.EY, B.MX, B.MY);
								if (Aa < 0.0) Aa += 1.0;
								if ((Aa < 0.24) || (Aa > 0.76))
									Reset = true;
								if (Bb < 0.0) Bb += 1.0;
								if ((Bb < 0.24) || (Bb > 0.76))
									Reset = true;
							}
							PA = A;
							PB = B;
							return true;
						}
					}
				}
				return false;
			}
			#endregion
			#region #method# ExtReturn(Size, Pos) 
			private bool ExtReturn(double Size, out double Pos) {
				var DIV = 0.5;
				var POS = 0.0;
				var TES = this;
				var Reset = false;
				Cubic NOW;
				Cubic RAM;
				Cubic PA = null;
				Cubic PB = null;
				RTES:
				if (TES.TesReturn(Size, ref PA, ref PB, out Reset)) {
					POS = 1.0;
				} else {
					NEXT:
					TES.Div(DIV, out NOW, out RAM);
					if (NOW.TesReturn(Size, ref PA, ref PB, out Reset)) {
						TES = RAM;
						POS += (1.0 - POS) * DIV; // Если ниже возвращения возникает отсечение
						if (Reset) { Pos = POS; return true; }
						DIV = 0.5;
						goto RTES;
					} else { DIV /= 2.0; if (DIV > 0.0) goto NEXT; }
				}
				Pos = POS;
				return false;
			}
			#endregion
			#region #method# ExtReturn(Size, Pos, PA, PB) 
			private bool ExtReturn(double Size, out double Pos, ref Cubic PA, ref Cubic PB) {
				var DIV = 0.5;
				var POS = 0.0;
				var TES = this;
				var Reset = false;
				Cubic NOW;
				Cubic RAM;
				RTES:
				if (TES.TesReturn(Size, ref PA, ref PB, out Reset)) {
					POS = 1.0;
				} else {
					NEXT:
					TES.Div(DIV, out NOW, out RAM);
					if (NOW.TesReturn(Size, ref PA, ref PB, out Reset)) {
						TES = RAM;
						POS += (1.0 - POS) * DIV; // Если ниже возвращения возникает отсечение
						if (Reset) { Pos = POS; return true; }
						DIV = 0.5;
						goto RTES;
					} else { DIV /= 2.0; if (DIV > 0.0) goto NEXT; }
				}
				Pos = POS;
				return false;
			}
			#endregion
			#region #method# ReturnRoots(Size, Roots) 
			/// <summary>Возвращает массив корней разворотов кубической кривой)</summary>
			/// <param name="Size">Толщина линии кривой, для которой вычисляются развороты)</param>
			/// <param name="Roots">Исходный массив корней, как правило результат метода Extrema)</param>
			/// <returns>Возвращаемый массив корней)</returns>
			public double[] ReturnRoots(double Size, double[] Roots = null) {
				var P = 0.0;
				var R = 0.0;
				var S = 0.0;
				var V = this;
				while (V.ExtReturn(Size, out P)) {
					V.Div(P, out V, out var Next);
					S = (1.0 - R) * P;
					R += S;
					Roots = AddRoots(R, Roots);
					V = Next;
				}
				return Roots;
			}
			#endregion
			#region #method# ReturnInRoots(Size, Roots) 
			/// <summary>Возвращает массив корней разворотов кубической кривой, использует корни)</summary>
			/// <param name="Size">Толщина линии кривой, для которой вычисляются развороты)</param>
			/// <param name="Roots">Исходный массив корней, как правило результат метода Extrema)</param>
			/// <returns>Возвращаемый массив корней)</returns>
			public double[] ReturnInRoots(double Size, double[] Roots = null) {
				var P = 0.0;
				var R = 0.0;
				var S = 0.0;
				var roots = ForDivRoots(Roots);
				var RAM = this;
				Cubic NOW;
				Cubic AP = null;
				Cubic BP = null;
				if (roots != null) {
					var L = roots.Length;
					if (L > 0) {
						var I = 0;
						var r = roots[I];
						while (I < L) {
							r = roots[I];
							RAM.Div(r, out NOW, out RAM);
							while (NOW.ExtReturn(Size, out P, ref AP, ref BP)) {
								NOW.Div(P, out NOW, out var NEX);
								S = (1.0 - R) * (r * P);
								R += S;
								Roots = AddRoots(R, Roots);
								NOW = NEX;
							}
							S = (1.0 - R) * r;
							R += S;
							I++;
						}
					}
				}
				NOW = RAM;
				while (NOW.ExtReturn(Size, out P, ref AP, ref BP)) {
					NOW.Div(P, out NOW, out var NEX);
					S = (1.0 - R) * P;
					R += S;
					Roots = AddRoots(R, Roots);
					NOW = NEX;
				}
				return Roots;
			}
			#endregion
			#region #method# AddArcE(P) 
			public override void AddArcE(PathSource P) {
				var S = P.Thickness / 2;
				var A = S * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var cmX = this.cmX;
				var cmY = this.cmY;
				var ceX = this.ceX;
				var ceY = this.ceY;
				var EX = this.EX;
				var EY = this.EY;
				var cmL = Mat.Sqrt(MX - cmX, MY - cmY);
				var ceL = Mat.Sqrt(EX - ceX, EY - ceY);
				var meL = Mat.Sqrt(MX - EX, MY - EY);
				if (ceL > 0.0) {
					if (Mat.Sqrt(MX - ceX, MY - ceY) > 0.0) {
						MX = ceX;
						MY = ceY;
						meL = ceL;
					}
				} else if (cmL > 0.0) {
					if (Mat.Sqrt(EX - cmX, EY - cmY) > 0.0) {
						MX = cmX;
						MY = cmY;
						meL = Mat.Sqrt(MX - EX, MY - EY);
					}
				}
				var YX = (EY - MY) / meL * S;
				var XY = (MX - EX) / meL * S;
				var AX = EX + YX;
				var AY = EY + XY;
				var BX = EX - YX;
				var BY = EY - XY;
				var CX = EX + (EX - MX) / meL * S;
				var CY = EY + (EY - MY) / meL * S;
				var a = new Cubic(AX, AY, (AX + (EY - AY) / S * A), (AY + (AX - EX) / S * A), (CX + (CY - EY) / S * A), (CY + (EX - CX) / S * A), CX, CY);
				var b = new Cubic(CX, CY, (CX + (EY - CY) / S * A), (CY + (CX - EX) / S * A), (BX + (BY - EY) / S * A), (BY + (EX - BX) / S * A), BX, BY);
				P.AddItem(a);
				P.AddItem(b);
			}
			#endregion
			#region #method# AddLinM(P) 
			public override void AddLinM(PathSource P) {
				var S = P.Thickness / 2;
				var A = S * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var cmX = this.cmX;
				var cmY = this.cmY;
				var ceX = this.ceX;
				var ceY = this.ceY;
				var EX = this.EX;
				var EY = this.EY;
				var cmL = Mat.Sqrt(MX - cmX, MY - cmY);
				var ceL = Mat.Sqrt(EX - ceX, EY - ceY);
				var meL = Mat.Sqrt(MX - EX, MY - EY);
				if (cmL > 0.0) {
					if (Mat.Sqrt(EX - cmX, EY - cmY) > 0.0) {
						EX = cmX;
						EY = cmY;
						meL = cmL;
					}
				} else if (ceL > 0.0) {
					if (Mat.Sqrt(MX - ceX, MY - ceY) > 0.0) {
						EX = ceX;
						EY = ceY;
						meL = Mat.Sqrt(MX - EX, MY - EY);
					}
				}
				var YX = (EY - MY) / meL * S;
				var XY = (MX - EX) / meL * S;
				var AX = MX + YX;
				var AY = MY + XY;
				var BX = MX - YX;
				var BY = MY - XY;
				P.AddItem(new Line(BX, BY, AX, AY));
			}
			#endregion
			#region #method# AddLinE(P) 
			public override void AddLinE(PathSource P) {
				var S = P.Thickness / 2;
				var A = S * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var cmX = this.cmX;
				var cmY = this.cmY;
				var ceX = this.ceX;
				var ceY = this.ceY;
				var EX = this.EX;
				var EY = this.EY;
				var cmL = Mat.Sqrt(MX - cmX, MY - cmY);
				var ceL = Mat.Sqrt(EX - ceX, EY - ceY);
				var meL = Mat.Sqrt(MX - EX, MY - EY);
				if (ceL > 0.0) {
					if (Mat.Sqrt(MX - ceX, MY - ceY) > 0.0) {
						MX = ceX;
						MY = ceY;
						meL = ceL;
					}
				} else if (cmL > 0.0) {
					if (Mat.Sqrt(EX - cmX, EY - cmY) > 0.0) {
						MX = cmX;
						MY = cmY;
						meL = Mat.Sqrt(MX - EX, MY - EY);
					}
				}
				var YX = (EY - MY) / meL * S;
				var XY = (MX - EX) / meL * S;
				var AX = EX + YX;
				var AY = EY + XY;
				var BX = EX - YX;
				var BY = EY - XY;
				P.AddItem(new Line(AX, AY, BX, BY));
			}
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
				var L0 = Mat.Sqrt(l0X, l0Y);
				var L2 = Mat.Sqrt(l2X, l2Y);
				Roots = AddRoots(l0X * 3, l1X * 3, l2X * 3, Roots);
				Roots = AddRoots(l0Y * 3, l1Y * 3, l2Y * 3, Roots);
				Roots = AddRoots(l0X * 2, l1X * 2, Roots);
				Roots = AddRoots(l0Y * 2, l1Y * 2, Roots);
				Roots = AddRoots(l1X * 2, l2X * 2, Roots);
				Roots = AddRoots(l1Y * 2, l2Y * 2, Roots);
				return Roots;
			}
			#endregion
			#region #property# Linear 
			/// <summary>Возвращает линейность кубической кривой)</summary>
			public bool Linear {
				get {
					var lMcm = Mat.Sqrt(cmX - MX, cmY - MY);
					var lEce = Mat.Sqrt(EX - ceX, EY - ceY);
					if (lMcm != 0.0 && lEce != 0.0) {
						return Inline(MX, MY, cmX, cmY, ceX, ceY) && Inline(EX, EY, ceX, ceY, cmX, cmY);
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
			#region #method# Change(Mod, Invert) 
			public override void Change(Change Mod, bool Invert) {
				var MX = this.MX; var MY = this.MY; var QX = this.QX; var QY = this.QY; var EX = this.EX; var EY = this.EY;
				while (Mod != null) {
					Mod.Modify(ref MX, ref MY, (Mod.Mods & Mods.MX) != 0, (Mod.Mods & Mods.MY) != 0);
					Mod.Modify(ref EX, ref EY, (Mod.Mods & Mods.EX) != 0, (Mod.Mods & Mods.EY) != 0);
					Mod.Modify(ref QX, ref QY, (Mod.Mods & Mods.QX) != 0, (Mod.Mods & Mods.QY) != 0);
					Mod = Mod.Next;
				}
				if (Invert) {
					this.MX = EX; this.MY = EY; this.EX = MX; this.EY = MY;
				} else {
					this.MX = MX; this.MY = MY; this.EX = EX; this.EY = EY;
				}
				this.QX = QX; this.QY = QY;
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
			#region #method# AddArcM(P) 
			public override void AddArcM(PathSource P) {
				var S = P.Thickness / 2;
				var A = S * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var QX = this.QX;
				var QY = this.QY;
				var EX = this.EX;
				var EY = this.EY;
				var cmL = Mat.Sqrt(MX - QX, MY - QY);
				var ceL = Mat.Sqrt(EX - QX, EY - QY);
				var meL = Mat.Sqrt(MX - EX, MY - EY);
				if (cmL > 0.0 && ceL > 0.0) { EX = QX; EY = QY; meL = cmL; }
				var YX = (EY - MY) / meL * S;
				var XY = (MX - EX) / meL * S;
				var AX = MX + YX;
				var AY = MY + XY;
				var BX = MX - YX;
				var BY = MY - XY;
				var CX = MX + (MX - EX) / meL * S;
				var CY = MY + (MY - EY) / meL * S;
				new Cubic(BX, BY, (BX + (MY - BY) / S * A), (BY + (BX - MX) / S * A), (CX + (CY - MY) / S * A), (CY + (MX - CX) / S * A), CX, CY).DivArc(out var a0, out var a1);
				new Cubic(CX, CY, (CX + (MY - CY) / S * A), (CY + (CX - MX) / S * A), (AX + (AY - MY) / S * A), (AY + (MX - AX) / S * A), AX, AY).DivArc(out var a2, out var a3);
				P.AddItem(a0);
				P.AddItem(a1);
				P.AddItem(a2);
				P.AddItem(a3);
			}
			#endregion
			#region #method# AddArcE(P) 
			public override void AddArcE(PathSource P) {
				var S = P.Thickness / 2;
				var A = S * Arc14;
				var MX = this.MX;
				var MY = this.MY;
				var QX = this.QX;
				var QY = this.QY;
				var EX = this.EX;
				var EY = this.EY;
				var cmL = Mat.Sqrt(MX - QX, MY - QY);
				var ceL = Mat.Sqrt(EX - QX, EY - QY);
				var meL = Mat.Sqrt(MX - EX, MY - EY);
				if (ceL > 0.0 && cmL > 0.0) { MX = QX; MY = QY; meL = ceL; }
				var YX = (EY - MY) / meL * S;
				var XY = (MX - EX) / meL * S;
				var AX = EX + YX;
				var AY = EY + XY;
				var BX = EX - YX;
				var BY = EY - XY;
				var CX = EX + (EX - MX) / meL * S;
				var CY = EY + (EY - MY) / meL * S;
				new Cubic(AX, AY, (AX + (EY - AY) / S * A), (AY + (AX - EX) / S * A), (CX + (CY - EY) / S * A), (CY + (EX - CX) / S * A), CX, CY).DivArc(out var a0, out var a1);
				new Cubic(CX, CY, (CX + (EY - CY) / S * A), (CY + (CX - EX) / S * A), (BX + (BY - EY) / S * A), (BY + (EX - BX) / S * A), BX, BY).DivArc(out var a2, out var a3);
				P.AddItem(a0);
				P.AddItem(a1);
				P.AddItem(a2);
				P.AddItem(a3);
			}
			#endregion
			#region #method# AddLinM(P) 
			public override void AddLinM(PathSource P) {
				var S = P.Thickness / 2;
				var MX = this.MX;
				var MY = this.MY;
				var QX = this.QX;
				var QY = this.QY;
				var EX = this.EX;
				var EY = this.EY;
				var cmL = Mat.Sqrt(MX - QX, MY - QY);
				var ceL = Mat.Sqrt(EX - QX, EY - QY);
				var meL = Mat.Sqrt(MX - EX, MY - EY);
				if (cmL > 0.0 && ceL > 0.0) { EX = QX; EY = QY; meL = cmL; }
				var YX = (EY - MY) / meL * S;
				var XY = (MX - EX) / meL * S;
				var AX = MX + YX;
				var AY = MY + XY;
				var BX = MX - YX;
				var BY = MY - XY;
				P.AddItem(new Line(BX, BY, AX, AY));
			}
			#endregion
			#region #method# AddLinE(P) 
			public override void AddLinE(PathSource P) {
				var S = P.Thickness / 2;
				var MX = this.MX;
				var MY = this.MY;
				var QX = this.QX;
				var QY = this.QY;
				var EX = this.EX;
				var EY = this.EY;
				var cmL = Mat.Sqrt(MX - QX, MY - QY);
				var ceL = Mat.Sqrt(EX - QX, EY - QY);
				var meL = Mat.Sqrt(MX - EX, MY - EY);
				if (ceL > 0.0 && cmL > 0.0) { MX = QX; MY = QY; meL = ceL; }
				var YX = (EY - MY) / meL * S;
				var XY = (MX - EX) / meL * S;
				var AX = EX + YX;
				var AY = EY + XY;
				var BX = EX - YX;
				var BY = EY - XY;
				P.AddItem(new Line(AX, AY, BX, BY));
			}
			#endregion
			#region #method# Dot(root) 
			public override Dot Dot(double root) {
				if (root < 0.0 || root > 1.0) throw new System.InvalidOperationException();
				var R = root;
				var x00 = MX;
				var y00 = MY;
				var x11 = QX;
				var y11 = QY;
				var x22 = EX;
				var y22 = EY;
				var x01 = (x11 - x00) * R + x00;
				var y01 = (y11 - y00) * R + y00;
				var x12 = (x22 - x11) * R + x11;
				var y12 = (y22 - y11) * R + y11;
				var x02 = (x12 - x01) * R + x01;
				var y02 = (y12 - y01) * R + y01;
				return new Dot(root, x02, y02, x12, y12, x01, y01);
			}
			#endregion
		}
		#endregion
		#region #method# Invert 
		public void Invert() {
			if (this.Inverted) {
				this.Inverted = false;
			} else {
				this.Inverted = true;
			}
		}
		#endregion
		#region #method# AddItemArc(Val, Acw) 
		public Item AddItemArc(Line Val, bool Acw = false) {
			return AddItem(Val.ToArcC(Acw));
		}
		#endregion
		#region #method# AddItemArc(MX, MY, EX, EY, Acw) 
		public Item AddItemArc(double MX, double MY, double EX, double EY, bool Acw = false) {
			return AddItemArc(new Line(MX, MY, EX, EY), Acw);
		}
		#endregion
		#region #method# AddBoneArc(Val, Acw) 
		public Bone AddBoneArc(Line Val, bool Acw = false) {
			return AddBone(Val.ToArcC(Acw));
		}
		#endregion
		#region #method# AddBoneArc(MX, MY, EX, EY, Acw) 
		public Bone AddBoneArc(double MX, double MY, double EX, double EY, bool Acw = false) {
			return AddBone(new Line(MX, MY, EX, EY).ToArcC(Acw));
		}
		#endregion
		#region #method# AddItemArc(MX, MY, EX, EY, r0, cw) 
		public Item AddItemArc(double MX, double MY, double EX, double EY, double r0, bool Acw = false) {
			return AddItem(new Line(MX, MY, EX, EY).ToArcC(Acw).Cuted(r0));
		}
		#endregion
		#region #method# AddBoneArc(MX, MY, EX, EY, r0, cw) 
		public Bone AddBoneArc(double MX, double MY, double EX, double EY, double r0, bool Acw = false) {
			return AddBone(new Line(MX, MY, EX, EY).ToArcC(Acw).Cuted(r0));
		}
		#endregion
		#region #method# AddItemArc(MX, MY, EX, EY, r0, r1, cw) 
		public Item AddItemArc(double MX, double MY, double EX, double EY, double r0, double r1, bool Acw = false) {
			return AddItem(new Line(MX, MY, EX, EY).ToArcC(Acw).Cuted(r0, r1));
		}
		#endregion
		#region #method# AddBoneArc(MX, MY, EX, EY, r0, r1, cw) 
		public Bone AddBoneArc(double MX, double MY, double EX, double EY, double r0, double r1, bool Acw = false) {
			return AddBone(new Line(MX, MY, EX, EY).ToArcC(Acw).Cuted(r0, r1));
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
						BeginFz();
						Invert();
						AddItemArc(x00, y00 + D, x01 - D, y01);
						AddItemArc(x10 - D, y10, x11, y11 - D);
						AddItemArc(x20, y20 - D, x21 + D, y21);
						AddItemArc(x30 + D, y30, x31, y31 + D);
						Invert();
					}
				}
				if (IsBonesUse) {
					AddBoneArc(x00, y00, x01, y01);
					AddBoneArc(x10, y10, x11, y11);
					AddBoneArc(x20, y20, x21, y21);
					AddBoneArc(x30, y30, x31, y31);
				}
			}
		}
		#endregion
		#region #method# AddKrug(X, Y, R) 
		/// <summary>Добавляет круг указанного радиуса)</summary>
		/// <param name="X">Горизонтальный центр круга)</param>
		/// <param name="Y">Вертикальный центр круга)</param>
		/// <param name="R">Радиус круга)</param>
		public void AddKrug(double X, double Y, double R) {
			AddItemArc(X, Y - R, X + R, Y);
			AddItemArc(X + R, Y, X, Y + R);
			AddItemArc(X, Y + R, X - R, Y);
			AddItemArc(X - R, Y, X, Y - R);
			if (IsBonesUse) {
				AddBoneArc(X, Y - R, X + R, Y);
				AddBoneArc(X + R, Y, X, Y + R);
				AddBoneArc(X, Y + R, X - R, Y);
				AddBoneArc(X - R, Y, X, Y - R);
			}
		}
		#endregion
		#region #method# AddAtr(tx, ty, rx, ry, Inverted) 
		/// <summary>Добавляет четверть круга где выпуклость сверху справа)</summary>
		public Item AddAtr(double TX, double TY, double RX, double RY, bool Inverted = false) {
			var C = new Cubic(TX, TY, TX, TY, RX, RY, RX, RY);
			var RTX = RX - TX;
			var RTY = RY - TY;
			if (TX < RX || RTX == RTY) { C.cmX += (RTX * Arc14); }
			if (TY < RY || RTX == RTY) { C.ceY -= (RTY * Arc14); }
			if (Inverted) C.Invert();
			return AddItem(C);
		}
		#endregion
		#region #method# AddArb(rx, ry, bx, by, Inverted) 
		/// <summary>Добавляет четверть круга где выпуклость справа снизу)</summary>
		public Item AddArb(double RX, double RY, double BX, double BY, bool Inverted = false) {
			var C = new Cubic(RX, RY, RX, RY, BX, BY, BX, BY);
			var BRY = BY - RY;
			var RBX = RX - BX;
			if (RY < BY || BRY == RBX) { C.cmY += (BRY * Arc14); }
			if (BX < RX || BRY == RBX) { C.ceX += (RBX * Arc14); }
			if (Inverted) C.Invert();
			return AddItem(C);
		}
		#endregion
		#region #method# AddAbl(bx, by, lx, ly, Inverted) 
		/// <summary>Добавляет четверть круга где выпуклость снизу слева)</summary>
		public Item AddAbl(double BX, double BY, double LX, double LY, bool Inverted = false) {
			var C = new Cubic(BX, BY, BX, BY, LX, LY, LX, LY);
			var BLX = BX - LX;
			var BLY = BY - LY;
			if (LX < BX || BLX == BLY) { C.cmX -= (BLX * Arc14); }
			if (LY < BY || BLX == BLY) { C.ceY += (BLY * Arc14); }
			if (Inverted) C.Invert();
			return AddItem(C);
		}
		#endregion
		#region #method# AddAlt(lx, ly, tx, ty, Inverted) 
		/// <summary>Добавляет четверть круга где выпуклость слева сверху)</summary>
		public Item AddAlt(double LX, double LY, double TX, double TY, bool Inverted = false) {
			var C = new Cubic(LX, LY, LX, LY, TX, TY, TX, TY);
			var LTY = LY - TY;
			var TLX = TX - LX;
			if (TY < LY || LTY == TLX) { C.cmY -= (LTY * Arc14); }
			if (LX < TX || LTY == TLX) { C.ceX -= (TLX * Arc14); }
			if (Inverted) C.Invert();
			return AddItem(C);
		}
		#endregion
		#region #method# GetAtr(tx, ty, rx, ry, Inverted) 
		/// <summary>Добавляет четверть круга где выпуклость сверху справа)</summary>
		public Cubic GetAtr(double TX, double TY, double RX, double RY, bool Inverted = false) {
			var C = new Cubic(TX, TY, TX, TY, RX, RY, RX, RY);
			var RTX = RX - TX;
			var RTY = RY - TY;
			if (TX < RX || RTX == RTY) { C.cmX += (RTX * Arc14); }
			if (TY < RY || RTX == RTY) { C.ceY -= (RTY * Arc14); }
			if (Inverted) C.Invert();
			return C;
		}
		#endregion
		#region #method# GetArb(rx, ry, bx, by, Inverted) 
		/// <summary>Добавляет четверть круга где выпуклость справа снизу)</summary>
		public Cubic GetArb(double RX, double RY, double BX, double BY, bool Inverted = false) {
			var C = new Cubic(RX, RY, RX, RY, BX, BY, BX, BY);
			var BRY = BY - RY;
			var RBX = RX - BX;
			if (RY < BY || BRY == RBX) { C.cmY += (BRY * Arc14); }
			if (BX < RX || BRY == RBX) { C.ceX += (RBX * Arc14); }
			if (Inverted) C.Invert();
			return C;
		}
		#endregion
		#region #method# GetAbl(bx, by, lx, ly, Inverted) 
		/// <summary>Добавляет четверть круга где выпуклость снизу слева)</summary>
		public Cubic GetAbl(double BX, double BY, double LX, double LY, bool Inverted = false) {
			var C = new Cubic(BX, BY, BX, BY, LX, LY, LX, LY);
			var BLX = BX - LX;
			var BLY = BY - LY;
			if (LX < BX || BLX == BLY) { C.cmX -= (BLX * Arc14); }
			if (LY < BY || BLX == BLY) { C.ceY += (BLY * Arc14); }
			if (Inverted) C.Invert();
			return C;
		}
		#endregion
		#region #method# GetAlt(lx, ly, tx, ty, Inverted) 
		/// <summary>Добавляет четверть круга где выпуклость слева сверху)</summary>
		public Cubic GetAlt(double LX, double LY, double TX, double TY, bool Inverted = false) {
			var C = new Cubic(LX, LY, LX, LY, TX, TY, TX, TY);
			var LTY = LY - TY;
			var TLX = TX - LX;
			if (TY < LY || LTY == TLX) { C.cmY -= (LTY * Arc14); }
			if (LX < TX || LTY == TLX) { C.ceX -= (TLX * Arc14); }
			if (Inverted) C.Invert();
			return C;
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
					this.FillRule = (Chr == '1');
					Index++;
				}
				Figure Fig = null;
				var Base = new DOT();
				var Prev = new DOT();
				var Last = new DOT();
				while (ParseToken(Val, ref Index, Count, ref Chr, ref Pre)) {
					if (Fig == null && Chr != 'm') throw new System.FormatException("NeededToken M UnexpectedToken " + Chr);
					switch (Chr) {
						#region #case# 'm' Начало 
						case 'm': {
								Fig = new Figure(this) { IsClozed = false, IsFilled = true };
								if (ParsePoint(Val, ref Index, Count, ref Base)) {
									while (ParsePoint(Val, ref Index, Count, ref Last)) {
										if (Pre) Last += Base;
										AddItem(Base.X, Base.Y, Last.X, Last.Y);
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
									AddItem(Base.X, Base.Y, Last.X, Last.Y);
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
									AddItem(Base.X, Base.Y, Last.X, Last.Y);
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
									AddItem(Base.X, Base.Y, Last.X, Last.Y);
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
									AddItem(Base.X, Base.Y, Prev.X, Prev.Y, Last.X, Last.Y);
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
									AddItem(Base.X, Base.Y, Prev.X, Prev.Y, Last.X, Last.Y);
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
									AddItem(Base.X, Base.Y, Next.X, Next.Y, Prev.X, Prev.Y, Last.X, Last.Y);
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
									AddItem(Base.X, Base.Y, Next.X, Next.Y, Prev.X, Prev.Y, Last.X, Last.Y);
									Base = Last;
								}
								Lot = 'c';
							}
							continue;
						#endregion
						#region #case# 'z' Замкнутый 
						case 'z': {
								Fig.IsClozed = true;
								Fig = null;
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
				if (FigureCount > 0) {
					var Figure = FigureBase;
					while (Figure != null) {
						if (Figure.ItemCount > 0) {
							Result += Figure.ToString();
						}
						Figure = Figure.Next;
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
				if (FigureCount > 0) {
					var Figure = FigureBase;
					while (Figure != null) {
						if (Figure.ItemCount > 0) {
							var Item = Figure.ItemBase;
							Item Prev = null;
							while (Item != null) {
								Result += Item.Value.ToCompessedString(Prev?.Value);
								Prev = Item;
								Item = Item.Next;
							}
							if (Figure.IsClozed) Result += "z";
						}
						Figure = Figure.Next;
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
			var D = this.Thickness;
			var IsRoundM = this.IsRoundM;
			var IsRoundE = this.IsRoundE;
			var RootM = this.RootM; this.RootM = null;
			var RootE = this.RootE; this.RootE = null;
			var Bone = new Line(x0, y0, x1, y1).Cuted(RootM, RootE);
			if (IsBonesUse) { AddBone(Bone); }
			x0 = Bone.MX;
			y0 = Bone.MY;
			x1 = Bone.EX;
			y1 = Bone.EY;
			var S = this.Thickness / 2;
			var A = S * Arc14;
			var x00 = Bone.MX;
			var y00 = Bone.MY;
			var x11 = Bone.EX;
			var y11 = Bone.EY;

			var L = Mat.Sqrt(x00 - x11, y00 - y11);
			var yx = (y11 - y00) / L * S;
			var xy = (x00 - x11) / L * S;
			var ax0 = x00 + yx;
			var ay0 = y00 + xy;
			var ax1 = x11 + yx;
			var ay1 = y11 + xy;
			var bx1 = x11 - yx;
			var by1 = y11 - xy;
			var bx0 = x00 - yx;
			var by0 = y00 - xy;
			if (IsRoundM) {
				var tx0 = x00 + (x00 - x11) / L * S;
				var ty0 = y00 + (y00 - y11) / L * S;
				new Cubic(bx0, by0, (bx0 + (y00 - by0) / S * A), (by0 + (bx0 - x00) / S * A), (tx0 + (ty0 - y00) / S * A), (ty0 + (x00 - tx0) / S * A), tx0, ty0).DivArc(out var a0, out var a1);
				new Cubic(tx0, ty0, (tx0 + (y00 - ty0) / S * A), (ty0 + (tx0 - x00) / S * A), (ax0 + (ay0 - y00) / S * A), (ay0 + (x00 - ax0) / S * A), ax0, ay0).DivArc(out var a2, out var a3);
				AddItem(a0);
				AddItem(a1);
				AddItem(a2);
				AddItem(a3);
			} else {
				AddItem(new Line(bx0, by0, ax0, ay0));
			}
			AddItem(new Line(ax0, ay0, ax1, ay1));
			if (IsRoundE) {
				var tx1 = x11 + (x11 - x00) / L * S;
				var ty1 = y11 + (y11 - y00) / L * S;
				new Cubic(ax1, ay1, (ax1 + (y11 - ay1) / S * A), (ay1 + (ax1 - x11) / S * A), (tx1 + (ty1 - y11) / S * A), (ty1 + (x11 - tx1) / S * A), tx1, ty1).DivArc(out var a0, out var a1);
				new Cubic(tx1, ty1, (tx1 + (y11 - ty1) / S * A), (ty1 + (tx1 - x11) / S * A), (bx1 + (by1 - y11) / S * A), (by1 + (x11 - bx1) / S * A), bx1, by1).DivArc(out var a2, out var a3);
				AddItem(a0);
				AddItem(a1);
				AddItem(a2);
				AddItem(a3);
			} else {
				AddItem(new Line(ax1, ay1, bx1, by1));
			}
			AddItem(new Line(bx1, by1, bx0, by0));
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
			if (IsBonesUse) { AddBone(Bone); }
			var Ideal = this.Ideal;

			var Roots = new double[0];
			Roots = Bone.Extrema(Roots);
			Roots = Bone.ReturnInRoots(Size, Roots);
			Cubic NOW;
			Cubic RAM = Bone;
			Roots = AddRoots(0.5, Roots);
			Roots = ForDivRoots(Roots);
			var L = Roots.Length;
			var Linear = Bone.Linear;
			if (!Linear && IsRoundM) RAM.AddArcM(this);
			for (var I = 0; I < L; I++) {
				RAM.Div(Roots[I], out NOW, out RAM);
				if (Linear && IsRoundM) NOW.AddArcM(this);
				NOW.NormalAddA(this);
				if (Linear && IsRoundE) NOW.AddArcE(this);
				NOW.NormalAddB(this);
				Union();
			}
			if (Linear && IsRoundM) RAM.AddArcM(this);
			RAM.NormalAddA(this);
			if (IsRoundE) RAM.AddArcE(this);
			RAM.NormalAddB(this);
		}
		#endregion
		#region #class# List 
		public class List<T> {
			/// <summary>Начинающий элмент в списке)</summary>
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Item Base;
			/// <summary>Завершающий элмент в списке)</summary>
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public Item Last;
			/// <summary>Число элементов в списке)</summary>
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public int Count;
			/// <summary>Число преломлений, разворотов)</summary>
			public int Reset;
			#region #class# Item 
			public class Item {
				public double Root;
				public double Size;
				public T Value;
				/// <summary>Истина определяет, что корень является преломлением, требует деления)</summary>
				public bool Reset;
				/// <summary>Предыдущий элмент в списке)</summary>
				#region #invisible# 
#if TRACE
				[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
				#endregion
				public Item Prev;
				/// <summary>Следующий элмент в списке)</summary>
				#region #invisible# 
#if TRACE
				[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
				#endregion
				public Item Next;
				public List<T> List;
				#region #method# Add(Now, Root, End) 
				public Item Add(T Now, double Root, T End) {
					var NowSize = this.Root + Root - this.Root;
					var EndRoot = this.Root + Root;
					var EndSize = this.Size - Root;
					this.Size = NowSize;
					var List = this.List;
					this.Value = Now;
					var Item = new Item() { Value = End, List = List, Root = EndRoot, Size = EndSize };
					var Next = this.Next;
					if (Next != null) {
						Next.Prev = Item;
						Item.Next = Next;
					} else {
						List.Last = Item;
					}
					this.Next = Item;
					Item.Prev = this;
					List.Count++;
					return Item;
				}
				#endregion
				public override string ToString() {
					var T = System.Globalization.CultureInfo.InvariantCulture;
					return "Item Root = " + this.Root.ToString(T) + " Size = " + this.Size.ToString(T) + " Bound = " + this.Bound.ToString(T) + "[" + this.Value + "]";
				}
				public double Bound {
					get { return this.Root + this.Size; }
				}
			}
			#endregion
			#region #through# 
#if TRACE
			[System.Diagnostics.DebuggerStepThrough]
#endif
			#endregion
			#region #method# Add(Value, Root,Size) 
			public Item Add(T Value, double Root, double Size) {
				var Item = new Item() { Value = Value, Root = Root, Size = Size, List = this };
				var Last = this.Last;
				if (Last == null) {
					this.Last = Item;
					this.Base = Item;
				} else {
					Last.Next = Item;
					this.Last = Item;
				}
				this.Count++;
				return Item;
			}
			#endregion
			#region #method# Add(List) 
			public void Add(List<T> List) {
				if (List != null && List.Base != null) {
					var Last = this.Last;
					if (Last == null) {
						this.Base = List.Base;
						this.Last = List.Last;
						this.Count = List.Count;
					} else {
						this.Last = List.Last;
						Last.Next = List.Base;
						List.Base.Prev = Last;
						this.Count += List.Count;
					}
					List.Base = null;
					List.Last = null;
					List.Count = 0;
					for (var Item = List.Base; Item != null; Item = Item.Next) {
						Item.List = this;
					}
				}
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
					var C = this.Count;
					var A = new Item[C];
					var I = 0;
					var Item = Base;
					while (Item != null) {
						A[I++] = Item;
						Item = Item.Next;
					}
					return A;
				}
			}
			#endregion
			public override string ToString() {
				return "List Count = " + this.Count.ToString();
			}
		}
		#endregion
	}
}
