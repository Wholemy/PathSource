namespace Wholemy {
	#region #class# PathFont 
	public abstract class PathFont {
		public Chr GetChr(char Char) {
			var P = Map.GetV(ref ChrMap, Char);
			if (P == null) {
				P = new UnknownChr(Char);
				Map.Add(ref ChrMap, Char, P);
			}
			return P;
		}
		private Map.Int<Chr> ChrMap;
		private Map.Chars<Chr> StrMap;
		public System.Windows.Media.Geometry GetGeometry(string Value, double Height, double Weight, out double Width) {
			var Count = Value.Length;
			Width = 0.0;
			var PathSource = new PathSource();
			for (int Index = 0; Index < Count; Index++) {
				var Char = Value[Index];
				var Chr = GetChr(Char);
				var Mul = Height / Chr.Height;
				PathSource.AddResizeMovA(WH: Mul, X: Width);
				PathSource.Begin();
				PathSource.Parse(Chr.GetWeight(Weight));
				PathSource.CutResize();
				Width += (Chr.Width * Mul);
			}
			return PathSource.CombineToGeometry();
		}
		public System.Windows.Media.Geometry GetGeometry(string Value, double Height, double Weight) {
			var Count = Value.Length;
			var Width = 0.0;
			var PathSource = new PathSource();
			for (int Index = 0; Index < Count; Index++) {
				var Char = Value[Index];
				var Chr = GetChr(Char);
				var Mul = Height / Chr.Height;
				PathSource.AddResizeMovA(WH: Mul, X: Width);
				PathSource.Begin();
				PathSource.Parse(Chr.GetWeight(Weight));
				PathSource.CutResize();
				Width += (Chr.Width * Mul);
			}
			return PathSource.CombineToGeometry();
		}
		public void ToPath(PathSource P,double X,double Y, string Value, double Height, double Weight) {
			var Count = Value.Length;
			var Width = X;
			var PathSource = P;
			for (int Index = 0; Index < Count; Index++) {
				var Char = Value[Index];
				var Chr = GetChr(Char);
				var Mul = Height / Chr.Height;
				PathSource.AddResizeMovA(WH: Mul, X: Width, Y:Y);
				PathSource.Begin();
				PathSource.Parse(Chr.GetWeight(Weight));
				PathSource.CutResize();
				Width += (Chr.Width * Mul);
			}
		}
		public double GetWidth(string Value, double Height) {
			var Count = Value.Length;
			var Width = 0.0;
			for (int Index = 0; Index < Count; Index++) {
				var Char = Value[Index];
				var Chr = GetChr(Char);
				var Mul = Height / Chr.Height;
				Width += (Chr.Width * Mul);
			}
			return Width;
		}
		#region #new# 
		public PathFont() {
			StrMap = new Map.Chars<Chr>();
			var LastType = this.GetType();
			while (LastType != null) {
				var NestedTypes = LastType.GetNestedTypes(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
				foreach (var NestedType in NestedTypes) {
					if (NestedType.IsClass && !NestedType.IsAbstract) {
						if (NestedType.IsSubclassOf(typeof(Chr))) {
							var Chr = (Chr)NestedType.GetConstructor(System.Type.EmptyTypes)?.Invoke(new object[0]);
							if (Chr != null) {
								var Str = Chr.Str;
								if (Str != null) {
									if (Str.Length == 1) {
										var C = Chr.Str[0];
										if (!Map.Add(ref ChrMap, C, Chr))
											throw new System.InvalidOperationException();
									} else if (Str.Length > 1) {
										var S = Chr.Str;
										if (!StrMap.Add(Chr, S))
											throw new System.InvalidOperationException();
									}
								}
								Chr.Font = this;
							}
						}
					}
				}
				LastType = LastType.BaseType;
			}
		}
		#endregion
		#region #class# Chr 
		public abstract class Chr {
			public PathFont Font;
			public string Str;
			public string Name;
			public double Width;
			public double Height;
			private Map.Double<string> CacheMap;
			public Chr(char Str) { this.Str = Str.ToString(); }
			public Chr(string Str) { this.Str = Str; }
			public Chr() { }
			public string GetWeight(double Weight) {
				var S = Map.GetV(ref CacheMap, Weight);
				if (S == null) {
					var L = Get(D: Weight / 4).Geometry;
					if (L != null) {
						S = Get(D: Weight / 4).Geometry.ToString();
					} else { S = ""; }
					Map.Add(ref CacheMap, Weight, S);
				}
				return S;
			}
			public abstract PathSource Get(double D = 0, PathSource Source = null);
			public override string ToString() => this.Str;
		}
		#endregion
		#region #class# UnknownChr 
		protected class UnknownChr : Chr {
			public UnknownChr(char chr) : base(chr) { Width = 1000; Height = 1000; }
			public override PathSource Get(double D = 0, PathSource Source = null) {
				var S = Source ?? new PathSource();
				if (D > 0) {
					D /= 2;
					S.Thickness = D;
					S.BeginFz();
					//S.AddRotate(45, 500, 500);
					//S.AddResizeMovA(XY: 100);
					S.AddArc00(50, 200, 200, 50);
					S.BeginFz();
					S.AddArc00(600, 50, 750, 200);
					S.BeginFz();
					S.AddArc00(750, 600, 600, 750);
					S.BeginFz();
					S.AddArc00(200, 750, 50, 600);
					S.BeginFz();
					S.AddLin00(200, 50, 600, 50);
					S.BeginFz();
					S.AddLin00(750, 200, 750, 600);
					S.BeginFz();
					S.AddLin00(600, 750, 200, 750);
					S.BeginFz();
					S.AddLin00(50, 600, 50, 200);
					//S.Thickness = 150 - D;
					var chr = (int)(ushort)this.Str[0];
					if (((chr >> 15) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(200, 200, 25);
					}
					if (((chr >> 14) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(200 + (400.0 / 3 * 1), 200, 25);
					}
					if (((chr >> 13) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(600 - (400.0 / 3 * 1), 200, 25);
					}
					if (((chr >> 12) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(600, 200, 25);
					}
					if (((chr >> 11) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(200, 200 + (400.0 / 3 * 1), 25);
					}
					if (((chr >> 10) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(200 + (400.0 / 3 * 1), 200 + (400.0 / 3 * 1), 25);
					}
					if (((chr >> 9) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(600 - (400.0 / 3 * 1), 200 + (400.0 / 3 * 1), 25);
					}
					if (((chr >> 8) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(600, 200 + (400.0 / 3 * 1), 25);
					}
					if (((chr >> 7) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(200, 600 - (400.0 / 3 * 1), 25);
					}
					if (((chr >> 6) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(200 + (400.0 / 3 * 1), 600 - (400.0 / 3 * 1), 25);
					}
					if (((chr >> 5) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(600 - (400.0 / 3 * 1), 600 - (400.0 / 3 * 1), 25);
					}
					if (((chr >> 4) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(600, 600 - (400.0 / 3 * 1), 25);
					}
					if (((chr >> 3) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(200, 600, 25);
					}
					if (((chr >> 4) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(200 + (400.0 / 3 * 1), 600, 25);
					}
					if (((chr >> 1) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(600 - (400.0 / 3 * 1), 600, 25);
					}
					if (((chr) & 1) == 1) {
						S.BeginFz();
						S.AddOrc(600, 600, 25);
					}
					//S.CutResize();
					//S.CutRotate();
					return S.Combine();
				}
				return S;
			}
		}
		#endregion
	}
	#endregion
}
