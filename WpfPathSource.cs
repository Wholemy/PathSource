namespace Wholemy {
	public class PathSource {
		private static readonly double Arc14 = 4.0 / 3.0 * System.Math.Tan(System.Math.PI * 0.125);
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
		public double Thickness;
		public bool IsBonesUse;
		public bool IsRoundM;
		public bool IsRoundE;
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
			public virtual char Prefix => 'C';
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
			public virtual char Prefix => 'Q';
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
			var IsRoundM = this.IsRoundM;
			var IsRoundE = this.IsRoundE;
			var RootM = this.RootM; this.RootM = null;
			var RootE = this.RootE; this.RootE = null;
			var D = this.Thickness;
			var C = new Line(x0, y0, x1, y1).ToArcC().Cuted(RootM, RootE);
			if (IsBonesUse) AddBone(new Line(x0, y0, x1, y1).ToArcC().Cuted(RootM, RootE));
			D /= 2;
			double x, y, xy, yx;
			if (x0 < x1) {
				x = x1 - x0;
				if (y0 < y1) { // Право верх
					y = y1 - y0;
					xy = x / y;
					yx = y / x;
					var O = GetAtr(x0, y0 - D, x1 + D, y1).Cuted(RootM, RootE);
					if (IsRoundM) {
						if (RootM != null) AddRotate(O.MX, O.MY, C.MX, C.MY, false);
						AddItemArc(C.MX, C.MY + D, C.MX - D, C.MY);
						AddItemArc(C.MX - D, C.MY, C.MX, C.MY - D);
						if (RootM != null) CutRotate();
						UnionFz();
					}
					if (IsRoundE) {
						if (RootE != null) AddRotate(O.EX, O.EY, C.EX, C.EY, true);
						AddItemArc(C.EX + D, C.EY, C.EX, C.EY + D);
						AddItemArc(C.EX, C.EY + D, C.EX - D, C.EY);
						if (RootE != null) CutRotate();
						UnionFz();
					}
					AddAtr(x0, y0 - D, x1 + D, y1).Value.Cuted(RootM, RootE);
					if (xy > 1.0) { AddRotate(x1 - (D / xy), y0, x1, y1, true, Mods.Mxy | Mods.cmxy); }
					if (yx > 1.0) { AddRotate(x1, y0 + (D / yx), x0, y0, false, Mods.Exy | Mods.cexy); }
					AddAtr(x0, y0 + D, x1 - D, y1, true).Value.Cuted(RootE, RootM);
					if (xy > 1.0 || yx > 1.0) { CutRotate(); }
				} else { // Лево верх
					y = y0 - y1;
					xy = x / y;
					yx = y / x;
					var O = GetAlt(x0 - D, y0, x1, y1 - D).Cuted(RootM, RootE);
					if (IsRoundM) {
						if (RootM != null) AddRotate(O.MX, O.MY, C.MX, C.MY, false);
						AddItemArc(C.MX + D, C.MY, C.MX, C.MY + D);
						AddItemArc(C.MX, C.MY + D, C.MX - D, C.MY);
						if (RootM != null) CutRotate();
						UnionFz();
					}
					if (IsRoundE) {
						if (RootE != null) AddRotate(O.EX, O.EY, C.EX, C.EY, true);
						AddItemArc(C.EX, C.EY - D, C.EX + D, C.EY);
						AddItemArc(C.EX + D, C.EY, C.EX, C.EY + D);
						if (RootE != null) CutRotate();
						UnionFz();
					}
					AddAlt(x0 - D, y0, x1, y1 - D).Value.Cuted(RootM, RootE);
					if (xy > 1.0) { AddRotate(x1, y0 + D, x0, y0, false, Mods.Exy | Mods.cexy); }
					if (yx > 1.0) { AddRotate(x1 + D, y0, x1, y1, true, Mods.Mxy | Mods.cmxy); }
					AddAlt(x0 + D, y0, x1, y1 + D, true).Value.Cuted(RootE, RootM);
					if (xy > 1.0 || yx > 1.0) { CutRotate(); }
				}
			} else {
				x = x0 - x1;
				if (y0 < y1) { // Право низ
					y = y1 - y0;
					xy = x / y;
					yx = y / x;
					var O = GetArb(x0 + D, y0, x1, y1 + D).Cuted(RootM, RootE);
					if (IsRoundM) {
						if (RootM != null) AddRotate(O.MX, O.MY, C.MX, C.MY, false);
						AddItemArc(C.MX - D, C.MY, C.MX, C.MY - D);
						AddItemArc(C.MX, C.MY - D, C.MX + D, C.MY);
						if (RootM != null) CutRotate();
						UnionFz();
					}
					if (IsRoundE) {
						if (RootE != null) AddRotate(O.EX, O.EY, C.EX, C.EY, true);
						AddItemArc(C.EX, C.EY + D, C.EX - D, C.EY);
						AddItemArc(C.EX - D, C.EY, C.EX, C.EY - D);
						if (RootE != null) CutRotate();
						UnionFz();
					}
					AddArb(x0 + D, y0, x1, y1 + D).Value.Cuted(RootM, RootE);
					if (xy > 1.0) { AddRotate(x1, y0 - D, x0, y0, false, Mods.Exy | Mods.cexy); }
					if (yx > 1.0) { AddRotate(x1 - D, y0, x1, y1, true, Mods.Mxy | Mods.cmxy); }
					AddArb(x0 - D, y0, x1, y1 - D, true).Value.Cuted(RootE, RootM);
					if (xy > 1.0 || yx > 1.0) { CutRotate(); }
				} else { // Лево низ
					y = y0 - y1;
					xy = x / y;
					yx = y / x;
					var O = GetAbl(x0, y0 + D, x1 - D, y1).Cuted(RootM, RootE);
					if (IsRoundM) {
						if (RootM != null) AddRotate(O.MX, O.MY, C.MX, C.MY, false);
						AddItemArc(C.MX, C.MY - D, C.MX + D, C.MY);
						AddItemArc(C.MX + D, C.MY, C.MX, C.MY + D);
						if (RootM != null) CutRotate();
						UnionFz();
					}
					if (IsRoundE) {
						if (RootE != null) AddRotate(O.EX, O.EY, C.EX, C.EY, true);
						AddItemArc(C.EX - D, C.EY, C.EX, C.EY - D);
						AddItemArc(C.EX, C.EY - D, C.EX + D, C.EY);
						if (RootE != null) CutRotate();
						UnionFz();
					}
					AddAbl(x0, y0 + D, x1 - D, y1).Value.Cuted(RootM, RootE);
					if (xy > 1.0) { AddRotate(x1 + (D / xy), y0, x1, y1, true, Mods.Mxy | Mods.cmxy); }
					if (yx > 1.0) { AddRotate(x1, y0 - (D / yx), x0, y0, false, Mods.Exy | Mods.cexy); }
					AddAbl(x0, y0 - D, x1 + D, y1, true).Value.Cuted(RootE, RootM);
					if (xy > 1.0 || yx > 1.0) { CutRotate(); }
				}
			}
		}
		#endregion
		#region #method# AddItemYrc(x0, y0, x1, y1, cw) 
		public Item AddItemYrc(double x0, double y0, double x1, double y1, bool cw = false) {
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
			return AddItem(x0, y0, x00, y00, x11, y11, x1, y1);
		}
		#endregion
		#region #method# AddItemXrc(x0, y0, x1, y1, cw) 
		public Item AddItemXrc(double x0, double y0, double x1, double y1, bool cw = false) {
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
			return AddItem(x0, y0, x00, y00, x11, y11, x1, y1);
		}
		#endregion
		#region #method# AddYrc00(x0, y0, x1, y1) 
		public void AddYrc00(double x0, double y0, double x1, double y1) {
			var D = this.Thickness;
			D /= 2;
			if (x0 < x1) {
				if (y0 < y1) { // Право верх
					AddItemYrc(x0 + D, y0, x1 + D, y1);
					AddItemYrc(x1 - D, y1, x0 - D, y0, true);
				} else { // Лево верх
					AddItemYrc(x0 + D, y0, x1 + D, y1);
					AddItemYrc(x1 - D, y1, x0 - D, y0, true);
				}
			} else {
				if (y0 < y1) { // Право низ
					AddItemYrc(x0 + D, y0, x1 + D, y1);
					AddItemYrc(x1 - D, y1, x0 - D, y0, true);
				} else { // Лево низ
					AddItemYrc(x0 + D, y0, x1 + D, y1);
					AddItemYrc(x1 - D, y1, x0 - D, y0, true);
				}
			}
		}
		#endregion
		#region #method# AddXrc00(x0, y0, x1, y1) 
		public void AddXrc00(double x0, double y0, double x1, double y1) {
			var D = this.Thickness;
			D /= 2;
			if (x0 < x1) {
				if (y0 < y1) { // Право верх
					AddItemXrc(x0, y0 + D, x1, y1 + D);
					AddItemXrc(x1, y1 - D, x0, y0 - D, true);
				} else { // Лево верх
					AddItemXrc(x0, y0 + D, x1, y1 + D);
					AddItemXrc(x1, y1 - D, x0, y0 - D, true);
				}
			} else {
				if (y0 < y1) { // Право низ
					AddItemXrc(x0, y0 + D, x1, y1 + D);
					AddItemXrc(x1, y1 - D, x0, y0 - D, true);
				} else { // Лево низ
					AddItemXrc(x0, y0 + D, x1, y1 + D);
					AddItemXrc(x1, y1 - D, x0, y0 - D, true);
				}
			}
		}
		#endregion
		#region #struct# Dot 
		public struct Dot {
			public double X;
			public double Y;
			public Dot(double X, double Y) { this.X = X; this.Y = Y; }
			public static Dot operator +(Dot A, Dot B) {
				A.X += B.X;
				A.Y += B.Y;
				return A;
			}
			public static Dot operator -(Dot Prev, Dot Last) {
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
				var Base = new Dot();
				var Prev = new Dot();
				var Last = new Dot();
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
								Dot Next = new Dot();
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
								Dot Next = new Dot();
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
		private static bool ParseCommaPoint(string Val, ref int Inx, int Cnt, ref Dot Dot) {
			var Index = Inx;
			Dot Num = new Dot();
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
		private static bool ParsePoint(string Val, ref int Inx, int Cnt, ref Dot Dot) {
			var Index = Inx;
			Dot Num = new Dot();
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
			D /= 2;
			if (x0 == x1) {
				if (y0 < y1) { // верх // низ
					if (IsRoundM) {
						AddItemArc(x0 - D, y0, x0, y0 - D); // верх // лево верх
						AddItemArc(x0, y0 - D, x0 + D, y0); // верх // верх право
					} else {
						AddItem(x0 - D, y0, x0 + D, y0); // верх
					}
					if (IsRoundE) {
						AddItemArc(x1 + D, y1, x1, y1 + D); // низ // право низ
						AddItemArc(x1, y1 + D, x1 - D, y1); // низ // низ лево
					} else {
						AddItem(x1 + D, y1, x1 - D, y1); // низ
					}
				} else { // низ // верх
					if (IsRoundM) {
						AddItemArc(x0 + D, y0, x0, y0 + D); // низ // право низ
						AddItemArc(x0, y0 + D, x0 - D, y0); // низ // низ лево
					} else {
						AddItem(x0 + D, y0, x0 - D, y0); // низ
					}
					if (IsRoundE) {
						AddItemArc(x1 - D, y1, x1, y1 - D); // верх // лево верх
						AddItemArc(x1, y1 - D, x1 + D, y1); // верх // верх право
					} else {
						AddItem(x1 - D, y1, x1 + D, y1); // верх
					}
				}
			} else if (x0 < x1) { // лево // право
				if (y0 == y1) {
					if (IsRoundM) {
						AddItemArc(x0, y0 + D, x0 - D, y0); // лево // низ лево
						AddItemArc(x0 - D, y0, x0, y0 - D); // лево // лево верх
					} else {
						AddItem(x0, y0 + D, x0, y0 - D); // лево
					}
					if (IsRoundE) {
						AddItemArc(x1, y1 - D, x1 + D, y1); // право // верх право
						AddItemArc(x1 + D, y1, x1, y1 + D); // право // право низ
					} else {
						AddItem(x1, y1 - D, x1, y1 + D); // право
					}
				} else if (y0 < y1) { // лево верх // право низ
					AddRotate(x1, y1, x0, y0);
					if (IsRoundM) {
						AddItemArc(x0, y0 + D, x0 - D, y0); // лево // низ лево
						AddItemArc(x0 - D, y0, x0, y0 - D); // лево // лево верх
					} else {
						AddItem(x0, y0 + D, x0, y0 - D); // лево
					}
					CutRotate();
					AddRotate(x0, y0, x1, y1);
					if (IsRoundE) {
						AddItemArc(x1, y1 - D, x1 + D, y1); // право // верх право
						AddItemArc(x1 + D, y1, x1, y1 + D); // право // право низ
					} else {
						AddItem(x1, y1 - D, x1, y1 + D); // право
					}
					CutRotate();
				} else { // лево низ // право верх
					AddRotate(x1, y1, x0, y0);
					if (IsRoundM) {
						AddItemArc(x0 + D, y0, x0, y0 + D); // низ // право низ
						AddItemArc(x0, y0 + D, x0 - D, y0); // низ // низ лево
					} else {
						AddItem(x0 + D, y0, x0 - D, y0); // низ
					}
					CutRotate();
					AddRotate(x0, y0, x1, y1);
					if (IsRoundE) {
						AddItemArc(x1 - D, y1, x1, y1 - D); // верх // лево верх
						AddItemArc(x1, y1 - D, x1 + D, y1); // верх // верх право
					} else {
						AddItem(x1 - D, y1, x1 + D, y1); // верх
					}
					CutRotate();
				}
			} else { // право // лево
				if (y0 == y1) {
					if (IsRoundM) {
						AddItemArc(x0, y0 - D, x0 + D, y0); // право // верх право
						AddItemArc(x0 + D, y0, x0, y0 + D); // право // право низ
					} else {
						AddItem(x0, y0 - D, x0, y0 + D); // право
					}
					if (IsRoundE) {
						AddItemArc(x1, y1 + D, x1 - D, y1); // лево // низ лево
						AddItemArc(x1 - D, y1, x1, y1 - D); // лево // лево верх
					} else {
						AddItem(x1, y1 + D, x1, y1 - D); // лево
					}
				} else if (y0 < y1) { // право верх // лево низ
					AddRotate(x1, y1, x0, y0);
					if (IsRoundM) {
						AddItemArc(x0 - D, y0, x0, y0 - D); // верх // лево верх
						AddItemArc(x0, y0 - D, x0 + D, y0); // верх // верх право
					} else {
						AddItem(x0 - D, y0, x0 + D, y0); // верх
					}
					CutRotate();
					AddRotate(x0, y0, x1, y1);
					if (IsRoundE) {
						AddItemArc(x1 + D, y1, x1, y1 + D); // низ // право низ
						AddItemArc(x1, y1 + D, x1 - D, y1); // низ // низ лево
					} else {
						AddItem(x1 + D, y1, x1 - D, y1); // низ
					}
					CutRotate();
				} else { // право низ // лево верх
					AddRotate(x1, y1, x0, y0);
					if (IsRoundM) {
						AddItemArc(x0, y0 - D, x0 + D, y0); // право // верх право
						AddItemArc(x0 + D, y0, x0, y0 + D); // право // право низ
					} else {
						AddItem(x0, y0 - D, x0, y0 + D); // право
					}
					CutRotate();
					AddRotate(x0, y0, x1, y1);
					if (IsRoundE) {
						AddItemArc(x1, y1 + D, x1 - D, y1); // лево // низ лево
						AddItemArc(x1 - D, y1, x1, y1 - D); // лево // лево верх
					} else {
						AddItem(x1, y1 + D, x1, y1 - D); // лево
					}
					CutRotate();
				}
			}
		}
		#endregion
	}
}
