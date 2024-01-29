namespace Wholemy {
	public class Mat {
		public static readonly double Arc14 = 4.0 / 3.0 * System.Math.Tan(System.Math.PI / 8);
		#region #method# longSqrt(X, Y) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public static decimal longSqrt(decimal X, decimal Y) {
			X = Y = X * X + Y * Y;
			var R = X * 0.5m;
			while (Y != R) { Y = R; R = (R + (X / R)) * 0.5m; }
			return R;
		}
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public static double longSqrt(double X, double Y) {
			#region #debug# 
#if DEBUG
			if (double.IsNaN(X) || double.IsNaN(Y)) throw new System.ArgumentOutOfRangeException();
#endif
			#endregion
			X = Y = X * X + Y * Y;
			var R = X * 0.5;
			while (Y != R) { Y = R; R = (R + (X / R)) * 0.5; }
			return R;
		}
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public static float longSqrt(float X, float Y) {
			#region #debug# 
#if DEBUG
			if (float.IsNaN(X) || float.IsNaN(Y)) throw new System.ArgumentOutOfRangeException();
#endif
			#endregion
			X = Y = X * X + Y * Y;
			var R = X * 0.5f;
			while (Y != R) { Y = R; R = (R + (X / R)) * 0.5f; }
			return R;
		}
		#endregion
		#region #method# Sqrt(X, Y) 
		#region #through# 
#if TRACE
		[System.Diagnostics.DebuggerStepThrough]
#endif
		#endregion
		public static double Sqrt(double X, double Y) {
			return System.Math.Sqrt(X * X + Y * Y);
		}
		#endregion
		#region #method# Path(x, y, X, Y) 
		public static double Path(double x, double y, out double X, out double Y) {
			var L = System.Math.Sqrt(x * x + y * y);
			X = -y / L;
			Y = x / L;
			return L;
		}
		#endregion
		#region #method# longGetAR(CX, CY, BX, BY, AX, AY) 
		/// <summary>Возвращает корень поворота от 0.0 до 4.0)</summary>
		/// <param name="CX">Центр по оси X)</param>
		/// <param name="CY">Центр по оси Y)</param>
		/// <param name="BX">Старт по оси X)</param>
		/// <param name="BY">Старт по оси Y)</param>
		/// <param name="AX">Конец по оси X)</param>
		/// <param name="AY">Конец по оси Y)</param>
		/// <returns>Возвращает корень поворота от 0.0 до 4.0)</returns>
		/// <exception cref="System.InvalidProgramException">
		/// Возникает в случае непредусмотренного состояния, требует исправления)</exception>
		public static float longGetAR(float CX, float CY, float BX, float BY, float AX, float AY) {
			var BL = longSqrt(CX - BX, CY - BY);
			if (BL == 0.0f) return 0.0f;
			var AL = longSqrt(CX - AX, CY - AY);
			if (AL == 0.0f) return 0.0f;
			AX = CX + (AX - CX) / AL * BL;
			AY = CY + (AY - CY) / AL * BL;
			AL = longSqrt(CX - AX, CY - AY);
			var X1 = CY - BY + CX; var Y1 = BX - CX + CY; // 90
			var X2 = CX - BX + CX; var Y2 = CY - BY + CY; // 180
			var X3 = BY - CY + CX; var Y3 = CX - BX + CY; // 270
			var L0 = longSqrt(BX - AX, BY - AY);
			var L1 = longSqrt(X1 - AX, Y1 - AY);
			var L2 = longSqrt(X2 - AX, Y2 - AY);
			var L3 = longSqrt(X3 - AX, Y3 - AY);
			float R = 0.0f, MX = 0.0f, MY = 0.0f, EX = 0.0f, EY = 0.0f;
			if (L0 < L2 && L0 < L3 && L1 < L2 && L1 <= L3) {
				R = 0.0f; MX = BX; MY = BY; EX = X1; EY = Y1;
			} else if (L1 < L3 && L1 < L0 && L2 < L3 && L2 <= L0) {
				R = 1.0f; MX = X1; MY = Y1; EX = X2; EY = Y2; L0 = L1; L1 = L2;
			} else if (L2 < L0 && L2 < L1 && L3 < L0 && L3 <= L1) {
				R = 2.0f; MX = X2; MY = Y2; EX = X3; EY = Y3; L0 = L2; L1 = L3;
			} else if (L3 < L1 && L3 < L2 && L0 < L1 && L0 <= L2) {
				R = 3.0f; MX = X3; MY = Y3; EX = BX; EY = BY; L1 = L0; L0 = L3;
			} else { throw new System.InvalidProgramException(); }
			var AR = 1.0f;
			while (L0 > 0.0f && (L2 = longSqrt(MX - EX, MY - EY)) > 0.0f) {
				AR *= 0.5f;
				L3 = L2 * 0.5f;
				BX = MX + (EX - MX) / L2 * L3;
				BY = MY + (EY - MY) / L2 * L3;
				L2 = longSqrt(CX - BX, CY - BY);
				BX = CX + (BX - CX) / L2 * BL;
				BY = CY + (BY - CY) / L2 * BL;
				L3 = longSqrt(AX - BX, AY - BY);
				if (L0 < L1) {
					if (EX == BX && EY == BY) break; if (L1 <= L3) break;
					EX = BX; EY = BY; L1 = L3;
				} else {
					if (MX == BX && MY == BY) break; if (L0 <= L3) break;
					MX = BX; MY = BY; L0 = L3; R += AR;
				}
			}
			return R;
		}
		/// <summary>Возвращает корень поворота от 0.0 до 4.0)</summary>
		/// <param name="CX">Центр по оси X)</param>
		/// <param name="CY">Центр по оси Y)</param>
		/// <param name="BX">Старт по оси X)</param>
		/// <param name="BY">Старт по оси Y)</param>
		/// <param name="AX">Конец по оси X)</param>
		/// <param name="AY">Конец по оси Y)</param>
		/// <returns>Возвращает корень поворота от 0.0 до 4.0)</returns>
		/// <exception cref="System.InvalidProgramException">
		/// Возникает в случае непредусмотренного состояния, требует исправления)</exception>
		public static double longGetAR(double CX, double CY, double BX, double BY, double AX, double AY) {
			var BL = longSqrt(CX - BX, CY - BY);
			if (BL == 0.0) return 0.0;
			var AL = longSqrt(CX - AX, CY - AY);
			if (AL == 0.0) return 0.0;
			AX = CX + (AX - CX) / AL * BL;
			AY = CY + (AY - CY) / AL * BL;
			AL = longSqrt(CX - AX, CY - AY);
			var X1 = CY - BY + CX; var Y1 = BX - CX + CY; // 90
			var X2 = CX - BX + CX; var Y2 = CY - BY + CY; // 180
			var X3 = BY - CY + CX; var Y3 = CX - BX + CY; // 270
			var L0 = longSqrt(BX - AX, BY - AY);
			var L1 = longSqrt(X1 - AX, Y1 - AY);
			var L2 = longSqrt(X2 - AX, Y2 - AY);
			var L3 = longSqrt(X3 - AX, Y3 - AY);
			double R = 0.0, MX = 0.0, MY = 0.0, EX = 0.0, EY = 0.0;
			if (L0 < L2 && L0 < L3 && L1 < L2 && L1 <= L3) {
				R = 0.0; MX = BX; MY = BY; EX = X1; EY = Y1;
			} else if (L1 < L3 && L1 < L0 && L2 < L3 && L2 <= L0) {
				R = 1.0; MX = X1; MY = Y1; EX = X2; EY = Y2; L0 = L1; L1 = L2;
			} else if (L2 < L0 && L2 < L1 && L3 < L0 && L3 <= L1) {
				R = 2.0; MX = X2; MY = Y2; EX = X3; EY = Y3; L0 = L2; L1 = L3;
			} else if (L3 < L1 && L3 < L2 && L0 < L1 && L0 <= L2) {
				R = 3.0; MX = X3; MY = Y3; EX = BX; EY = BY; L1 = L0; L0 = L3;
			} else { throw new System.InvalidProgramException(); }
			var AR = 1.0;
			while (L0 > 0.0 && (L2 = longSqrt(MX - EX, MY - EY)) > 0.0) {
				AR *= 0.5;
				L3 = L2 * 0.5;
				BX = MX + (EX - MX) / L2 * L3;
				BY = MY + (EY - MY) / L2 * L3;
				L2 = longSqrt(CX - BX, CY - BY);
				BX = CX + (BX - CX) / L2 * BL;
				BY = CY + (BY - CY) / L2 * BL;
				L3 = longSqrt(AX - BX, AY - BY);
				if (L0 < L1) {
					if (EX == BX && EY == BY) break; if (L1 <= L3) break;
					EX = BX; EY = BY; L1 = L3;
				} else {
					if (MX == BX && MY == BY) break; if (L0 <= L3) break;
					MX = BX; MY = BY; L0 = L3; R += AR;
				}
			}
			return R;
		}
		/// <summary>Возвращает корень поворота от 0.0 до 4.0)</summary>
		/// <param name="CX">Центр по оси X)</param>
		/// <param name="CY">Центр по оси Y)</param>
		/// <param name="BX">Старт по оси X)</param>
		/// <param name="BY">Старт по оси Y)</param>
		/// <param name="AX">Конец по оси X)</param>
		/// <param name="AY">Конец по оси Y)</param>
		/// <returns>Возвращает корень поворота от 0.0 до 4.0)</returns>
		/// <exception cref="System.InvalidProgramException">
		/// Возникает в случае непредусмотренного состояния, требует исправления)</exception>
		public static decimal longGetAR(decimal CX, decimal CY, decimal BX, decimal BY, decimal AX, decimal AY) {
			var BL = longSqrt(CX - BX, CY - BY);
			if (BL == 0.0m) return 0.0m;
			var AL = longSqrt(CX - AX, CY - AY);
			if (AL == 0.0m) return 0.0m;
			AX = CX + (AX - CX) / AL * BL;
			AY = CY + (AY - CY) / AL * BL;
			AL = longSqrt(CX - AX, CY - AY);
			var X1 = CY - BY + CX; var Y1 = BX - CX + CY; // 90
			var X2 = CX - BX + CX; var Y2 = CY - BY + CY; // 180
			var X3 = BY - CY + CX; var Y3 = CX - BX + CY; // 270
			var L0 = longSqrt(BX - AX, BY - AY);
			var L1 = longSqrt(X1 - AX, Y1 - AY);
			var L2 = longSqrt(X2 - AX, Y2 - AY);
			var L3 = longSqrt(X3 - AX, Y3 - AY);
			decimal R = 0.0m, MX = 0.0m, MY = 0.0m, EX = 0.0m, EY = 0.0m;
			if (L0 < L2 && L0 < L3 && L1 < L2 && L1 <= L3) {
				R = 0.0m; MX = BX; MY = BY; EX = X1; EY = Y1;
			} else if (L1 < L3 && L1 < L0 && L2 < L3 && L2 <= L0) {
				R = 1.0m; MX = X1; MY = Y1; EX = X2; EY = Y2; L0 = L1; L1 = L2;
			} else if (L2 < L0 && L2 < L1 && L3 < L0 && L3 <= L1) {
				R = 2.0m; MX = X2; MY = Y2; EX = X3; EY = Y3; L0 = L2; L1 = L3;
			} else if (L3 < L1 && L3 < L2 && L0 < L1 && L0 <= L2) {
				R = 3.0m; MX = X3; MY = Y3; EX = BX; EY = BY; L1 = L0; L0 = L3;
			} else { throw new System.InvalidProgramException(); }
			var AR = 1.0m;
			while (L0 > 0.0m && (L2 = longSqrt(MX - EX, MY - EY)) > 0.0m) {
				AR *= 0.5m;
				L3 = L2 * 0.5m;
				BX = MX + (EX - MX) / L2 * L3;
				BY = MY + (EY - MY) / L2 * L3;
				L2 = longSqrt(CX - BX, CY - BY);
				BX = CX + (BX - CX) / L2 * BL;
				BY = CY + (BY - CY) / L2 * BL;
				L3 = longSqrt(AX - BX, AY - BY);
				if (L0 < L1) {
					if (EX == BX && EY == BY) break; if (L1 <= L3) break;
					EX = BX; EY = BY; L1 = L3;
				} else {
					if (MX == BX && MY == BY) break; if (L0 <= L3) break;
					MX = BX; MY = BY; L0 = L3; R += AR;
				}
			}
			return R;
		}
		#endregion
		#region #method# longRotate(CX, CY, BX, BY, AR) 
		/// <summary>Поворачивает координаты #float# вокруг центра по корню четверти круга
		/// где 90 градусов равно значению 1.0 а 360 градусов равно значению 4.0)</summary>
		/// <param name="CX">Центр по оси X)</param>
		/// <param name="CY">Центр по оси Y)</param>
		/// <param name="BX">Старт и возвращаемый результат поворота по оси X)</param>
		/// <param name="BY">Старт и возвращаемый результат поворота по оси Y)</param>
		/// <param name="AR">Корень четверти от 0.0 до 4.0 отрицательная в обратную сторону)</param>
		public static bool longRotate(float CX, float CY, ref float BX, ref float BY, float AR) {
			if (AR == 0.0f) return false;
			var Len = longSqrt(CX - BX, CY - BY);
			if (Len == 0.0f) return false;
			var R = (int)AR;
			if (AR < 0.0) { AR = 1.0f + (AR - R); R %= 4; R += 3; } else { AR -= R; R %= 4; }
			var MX = BX; var MY = BY;
			if (R == 1) { MX = CY - BY + CX; MY = BX - CX + CY; } // 90
			else if (R == 2) { MX = CX - BX + CX; MY = CY - BY + CY; } // 180
			else if (R == 3) { MX = BY - CY + CX; MY = CX - BX + CY; } // 270
			var EX = BX; var EY = BY; BX = MX; BY = MY;
			if (AR > 0.0f && R >= 0 && R < 3) { EX = CY - MY + CX; EY = MX - CX + CY; } // 90
			while (AR > 0.0f && AR < 1.0f) {
				var L = longSqrt(MX - EX, MY - EY);
				if (L == 0.0f) break;
				var ll = L / 2f;
				if (AR < 0.5f) {
					EX = MX + (EX - MX) / L * ll; EY = MY + (EY - MY) / L * ll;
					ll = longSqrt(CX - EX, CY - EY);
					EX = CX + (EX - CX) / ll * Len; EY = CY + (EY - CY) / ll * Len;
					AR = AR * 2.0f; BX = EX; BY = EY;
				} else {
					MX = EX + (MX - EX) / L * ll; MY = EY + (MY - EY) / L * ll;
					ll = longSqrt(CX - MX, CY - MY);
					MX = CX + (MX - CX) / ll * Len; MY = CY + (MY - CY) / ll * Len;
					AR = (AR - 0.5f) * 2.0f; BX = MX; BY = MY;
				}
			}
			return true;
		}
		/// <summary>Поворачивает координаты #double# вокруг центра по корню четверти круга
		/// где 90 градусов равно значению 1.0 а 360 градусов равно значению 4.0)</summary>
		/// <param name="CX">Центр по оси X)</param>
		/// <param name="CY">Центр по оси Y)</param>
		/// <param name="BX">Старт и возвращаемый результат поворота по оси X)</param>
		/// <param name="BY">Старт и возвращаемый результат поворота по оси Y)</param>
		/// <param name="AR">Корень четверти от 0.0 до 4.0 отрицательная в обратную сторону)</param>
		public static bool longRotate(double CX, double CY, ref double BX, ref double BY, double AR) {
			if (AR == 0.0) return false;
			var Len = longSqrt(CX - BX, CY - BY);
			if (Len == 0.0) return false;
			var R = (long)AR;
			if (AR < 0.0) { AR = 1.0 + (AR - R); R %= 4; R += 3; } else { AR -= R; R %= 4; }
			var MX = BX; var MY = BY;
			if (R == 1) { MX = CY - BY + CX; MY = BX - CX + CY; } // 90
			else if (R == 2) { MX = CX - BX + CX; MY = CY - BY + CY; } // 180
			else if (R == 3) { MX = BY - CY + CX; MY = CX - BX + CY; } // 270
			var EX = BX; var EY = BY; BX = MX; BY = MY;
			if (AR > 0.0 && R >= 0 && R < 3) { EX = CY - MY + CX; EY = MX - CX + CY; } // 90
			while (AR > 0.0 && AR < 1.0) {
				var L = longSqrt(MX - EX, MY - EY);
				if (L == 0.0) break;
				var ll = L / 2;
				if (AR < 0.5) {
					EX = MX + (EX - MX) / L * ll; EY = MY + (EY - MY) / L * ll;
					ll = longSqrt(CX - EX, CY - EY);
					EX = CX + (EX - CX) / ll * Len; EY = CY + (EY - CY) / ll * Len;
					AR = AR * 2.0; BX = EX; BY = EY;
				} else {
					MX = EX + (MX - EX) / L * ll; MY = EY + (MY - EY) / L * ll;
					ll = longSqrt(CX - MX, CY - MY);
					MX = CX + (MX - CX) / ll * Len; MY = CY + (MY - CY) / ll * Len;
					AR = (AR - 0.5) * 2.0; BX = MX; BY = MY;
				}
			}
			return true;
		}
		/// <summary>Поворачивает координаты #decimal# вокруг центра по корню четверти круга
		/// где 90 градусов равно значению 1.0 а 360 градусов равно значению 4.0)</summary>
		/// <param name="CX">Центр по оси X)</param>
		/// <param name="CY">Центр по оси Y)</param>
		/// <param name="BX">Старт и возвращаемый результат поворота по оси X)</param>
		/// <param name="BY">Старт и возвращаемый результат поворота по оси Y)</param>
		/// <param name="AR">Корень четверти от 0.0 до 4.0 отрицательная в обратную сторону)</param>
		public static bool longRotate(decimal CX, decimal CY, ref decimal BX, ref decimal BY, decimal AR) {
			if (AR == 0.0m) return false;
			var Len = longSqrt(CX - BX, CY - BY);
			if (Len == 0.0m) return false;
			var R = (long)AR;
			if (AR < 0.0m) { AR = 1.0m + (AR - R); R %= 4; R += 3; } else { AR -= R; R %= 4; }
			var MX = BX; var MY = BY;
			if (R == 1) { MX = CY - BY + CX; MY = BX - CX + CY; } // 90
			else if (R == 2) { MX = CX - BX + CX; MY = CY - BY + CY; } // 180
			else if (R == 3) { MX = BY - CY + CX; MY = CX - BX + CY; } // 270
			var EX = BX; var EY = BY; BX = MX; BY = MY;
			if (AR > 0.0m && R >= 0 && R < 3) { EX = CY - MY + CX; EY = MX - CX + CY; } // 90
			while (AR > 0.0m && AR < 1.0m) {
				var L = longSqrt(MX - EX, MY - EY);
				if (L == 0.0m) break;
				var ll = L / 2;
				if (AR < 0.5m) {
					EX = MX + (EX - MX) / L * ll; EY = MY + (EY - MY) / L * ll;
					ll = longSqrt(CX - EX, CY - EY);
					EX = CX + (EX - CX) / ll * Len; EY = CY + (EY - CY) / ll * Len;
					AR = AR * 2.0m; BX = EX; BY = EY;
				} else {
					MX = EX + (MX - EX) / L * ll; MY = EY + (MY - EY) / L * ll;
					ll = longSqrt(CX - MX, CY - MY);
					MX = CX + (MX - CX) / ll * Len; MY = CY + (MY - CY) / ll * Len;
					AR = (AR - 0.5m) * 2.0m; BX = MX; BY = MY;
				}
			}
			return true;
		}
		#endregion
		#region #method# Rotate(CX, CY, BX, BY, AR) 
		/// <summary>Поворачивает координаты #double# вокруг центра по корню четверти круга
		/// где 90 градусов равно значению 1, а 360 градусов равно значению 4)</summary>
		/// <param name="CX">Центр по оси X)</param>
		/// <param name="CY">Центр по оси Y)</param>
		/// <param name="BX">Старт и возвращаемый результат поворота по оси X)</param>
		/// <param name="BY">Старт и возвращаемый результат поворота по оси Y)</param>
		/// <param name="AR">Корень четверти от 0.0 до 4.0 отрицательная в обратную сторону)</param>
		public static void Rotate(double CX, double CY, ref double BX, ref double BY, double AR) {
			if (AR == 0.0) return;
			var TX = BX - CX;
			var TY = BY - CY;
			if (TX == 0.0 && TY == 0.0) return;
			var PI = System.Math.PI / 2 * AR;
			var Cos = System.Math.Cos(PI);
			var Sin = System.Math.Sin(PI);
			var X = (Cos * TX - Sin * TY + CX);
			var Y = (Sin * TX + Cos * TY + CY);
			BX = X;
			BY = Y;
		}
		#endregion
		#region #method# GetAR(CX, CY, BX, BY, AX, AY) 
		/// <summary>Возвращает корень поворота от 0.0 до 4.0)</summary>
		/// <param name="CX">Центр по оси X)</param>
		/// <param name="CY">Центр по оси Y)</param>
		/// <param name="BX">Старт по оси X)</param>
		/// <param name="BY">Старт по оси Y)</param>
		/// <param name="AX">Конец по оси X)</param>
		/// <param name="AY">Конец по оси Y)</param>
		/// <returns>Возвращает корень поворота от 0.0 до 4.0)</returns>
		public static double GetAR(double CX, double CY, double BX, double BY, double AX, double AY) {
			return (2 / System.Math.PI) * (System.Math.Atan2(AY - CY, AX - CX) - System.Math.Atan2(BY - CY, BX - CX));
		}
		#endregion
		#region #method# SetA1(CX, CY, BX, BY, AR) 
		/// <summary>Поворачивает координаты #double# вокруг центра по корню четверти круга
		/// где 90 градусов равно значению 1, а 360 градусов равно значению 4)</summary>
		/// <param name="CX">Центр по оси X)</param>
		/// <param name="CY">Центр по оси Y)</param>
		/// <param name="BX">Старт и возвращаемый результат поворота по оси X)</param>
		/// <param name="BY">Старт и возвращаемый результат поворота по оси Y)</param>
		/// <param name="AR">Корень четверти от 0.0 до 4.0 отрицательная в обратную сторону)</param>
		public static void SetA1(double CX, double CY, ref double BX, ref double BY, double AR) {
			if (AR == 0.0) return;
			var TX = BX - CX;
			var TY = BY - CY;
			if (TX == 0.0 && TY == 0.0) return;
			var PI = System.Math.PI / 0.5 * AR;
			var Cos = System.Math.Cos(PI);
			var Sin = System.Math.Sin(PI);
			var X = (Cos * TX - Sin * TY + CX);
			var Y = (Sin * TX + Cos * TY + CY);
			BX = X;
			BY = Y;
		}
		#endregion
		#region #method# GetA1(CX, CY, BX, BY, AX, AY) 
		/// <summary>Возвращает корень поворота от 0.0 до 1.0)</summary>
		/// <param name="CX">Центр по оси X)</param>
		/// <param name="CY">Центр по оси Y)</param>
		/// <param name="BX">Старт по оси X)</param>
		/// <param name="BY">Старт по оси Y)</param>
		/// <param name="AX">Конец по оси X)</param>
		/// <param name="AY">Конец по оси Y)</param>
		/// <returns>Возвращает корень поворота от 0.0 до 1.0)</returns>
		public static double GetA1(double CX, double CY, double BX, double BY, double AX, double AY) {
			return (0.5 / System.Math.PI) * (System.Math.Atan2(AY - CY, AX - CX) - System.Math.Atan2(BY - CY, BX - CX));
		}
		#endregion
		#region #method# Cubic14(CX, CY, MX, MY, cmX, cmY, ceX, ceY, EX, EY) 
		/// <summary>Получение точного тангенса кривой 1/4 круга, возвращает координаты кубической кривой по часовой стрелке и тангенс)</summary>
		/// <param name="CX">Центр круга по X координате)</param>
		/// <param name="CY">Центр круга по Y координате)</param>
		/// <param name="MX">X - Координата стартовой точки)</param>
		/// <param name="MY">Y - Координата стартовой точки)</param>
		/// <param name="cmX">X - Координата стартовой направляющей)</param>
		/// <param name="cmY">Y - Координата стартовой направляющей)</param>
		/// <param name="ceX">X - Координата конечной направляющей)</param>
		/// <param name="ceY">Y - Координата конечной направляющей)</param>
		/// <param name="EX">X - Координата конечной точки)</param>
		/// <param name="EY">Y - Координата конечной точки)</param>
		/// <returns>Тангенс 1/4 круга, возвращает значение близкое к 0.55228474983079356 аналог 4/3*Tan(PI/8) = 0.55228474983079334)</returns>
		public static double Cubic14(double CX, double CY, double MX, double MY, out double cmX, out double cmY, out double ceX, out double ceY, out double EX, out double EY) {
			var L = Sqrt(MX - CX, MY - CY); // Общая длина
			var HL = L * 0.5; // Половина длины
			var S = HL / L;
			var BX = CY - MY + CX; // Поворот на 90 градусов по часовой стрелке BX
			var BY = MX - CX + CY; // Поворот на 90 градусов по часовой стрелке BY
			var DX = BY - CY + BX; // Поворот на 90 градусов по часовой стрелке DX
			var DY = CX - BX + BY; // Поворот на 90 градусов по часовой стрелке DY
			Next:
			var ADX = MX + (DX - MX) / L * HL; // Перемещение от АX до DX на половину длины
			var ADY = MY + (DY - MY) / L * HL; // Перемещение от АY до DY на половину длины
			var BDX = BX + (DX - BX) / L * HL; // Перемещение от BX до DX на половину длины
			var BDY = BY + (DY - BY) / L * HL; // Перемещение от BY до DY на половину длины
			var ABDL = Sqrt(BDX - ADX, BDY - ADY);
			var ABDH = ABDL / 2.0;
			var ABDX = ADX + (BDX - ADX) / ABDL * ABDH;
			var ABDY = ADY + (BDY - ADY) / ABDL * ABDH;
			var AADL = Sqrt(ADX - MX, ADY - MY);
			var AADH = AADL / 2.0;
			var AADX = MX + (ADX - MX) / AADL * AADH;
			var AADY = MY + (ADY - MY) / AADL * AADH;
			var BBDL = Sqrt(BDX - BX, BDY - BY);
			var BBDH = BBDL / 2.0;
			var BBDX = BX + (BDX - BX) / BBDL * BBDH;
			var BBDY = BY + (BDY - BY) / BBDL * BBDH;
			var AAL = Sqrt(ABDX - AADX, ABDY - AADY);
			var AAH = AAL / 2.0;
			var AAX = AADX + (ABDX - AADX) / AAL * AAH;
			var AAY = AADY + (ABDY - AADY) / AAL * AAH;
			var BBL = Sqrt(ABDX - BBDX, ABDY - BBDY);
			var BBH = BBL / 2.0;
			var BBX = BBDX + (ABDX - BBDX) / BBL * BBH;
			var BBY = BBDY + (ABDY - BBDY) / BBL * BBH;
			var ABL = Sqrt(BBX - AAX, BBY - AAY);
			var ABH = ABL / 2.0;
			var ABX = AAX + (BBX - AAX) / ABL * ABH;
			var ABY = AAY + (BBY - AAY) / ABL * ABH;
			var N = Sqrt(ABX - CX, ABY - CY);
			if (N < L) {
				HL += S; goto Next;
			} else if (N > L) {
				HL -= S;
				if (S > 0.00000000000000001) {
					S /= 2; HL += S;
					goto Next;
				}
			} else if (S > 0.00000000000000001) {
				S /= 2; HL += S; goto Next;
			}
			cmX = ADX;
			cmY = ADY;
			ceX = BDX;
			ceY = BDY;
			EX = BX;
			EY = BY;
			return HL / L;
		}
		#endregion
		#region #method# Cubic18(CX, CY, MX, MY, cmX, cmY, ceX, ceY, EX, EY) 
		/// <summary>Получение точного тангенса кривой 1/8 круга, возвращает координаты кубической кривой по часовой стрелке и тангенс)</summary>
		/// <param name="CX">Центр круга по X координате)</param>
		/// <param name="CY">Центр круга по Y координате)</param>
		/// <param name="MX">X - Координата стартовой точки)</param>
		/// <param name="MY">Y - Координата стартовой точки)</param>
		/// <param name="cmX">X - Координата стартовой направляющей)</param>
		/// <param name="cmY">Y - Координата стартовой направляющей)</param>
		/// <param name="ceX">X - Координата конечной направляющей)</param>
		/// <param name="ceY">Y - Координата конечной направляющей)</param>
		/// <param name="EX">X - Координата конечной точки)</param>
		/// <param name="EY">Y - Координата конечной точки)</param>
		/// <returns>Тангенс 1/8 круга, возвращает значение близкое к 0.26521648983954449 аналог 4/3*Tan(PI/16) = 0.265216489839544)</returns>
		public static double Cubic18(double CX, double CY, double MX, double MY, out double cmX, out double cmY, out double ceX, out double ceY, out double EX, out double EY) {
			var L = Sqrt(MX - CX, MY - CY); // Общая длина
			var HL = L * 0.25; // Четверть длины
			var S = HL / L;
			var BX = CY - MY + CX; // Поворот на 90 градусов по часовой стрелке MY вокруг СX
			var BY = MX - CX + CY; // Поворот на 90 градусов по часовой стрелке MX вокруг СY
			var DX = BY - CY + BX; // Поворот на 90 градусов по часовой стрелке DX
			var DY = CX - BX + BY; // Поворот на 90 градусов по часовой стрелке DY
			var HABL = Sqrt(BX - MX, BY - MY); // Получение длины от M до B
			var HABH = HABL / 2.0; // Центр квадрата
			var HABX = MX + (BX - MX) / HABL * HABH; // Координата центра квадрата по X
			var HABY = MY + (BY - MY) / HABL * HABH; // Координата центра квадрата по Y
			BX = CX + (HABX - CX) / HABH * L; // Смещение координаты от центра до края круга по X
			BY = CY + (HABY - CY) / HABH * L; // Смещение координаты от центра до края круга по X
			var RX = BY - CY + BX; // Поворот на 90 градусов по часовой стрелке X
			var RY = CX - BX + BY; // Поворот на 90 градусов по часовой стрелке Y
			Next:
			var ADX = MX + (DX - MX) / L * HL; // Перемещение от АX до DX на половину длины
			var ADY = MY + (DY - MY) / L * HL; // Перемещение от АY до DY на половину длины
			var BRX = BX + (RX - BX) / L * HL; // Перемещение от BX до RX на половину длины
			var BRY = BY + (RY - BY) / L * HL; // Перемещение от BY до RY на половину длины
			var ABDL = Sqrt(BRX - ADX, BRY - ADY);
			var ABDH = ABDL / 2.0;
			var ABDX = ADX + (BRX - ADX) / ABDL * ABDH;
			var ABDY = ADY + (BRY - ADY) / ABDL * ABDH;
			var AADL = Sqrt(ADX - MX, ADY - MY);
			var AADH = AADL / 2.0;
			var AADX = MX + (ADX - MX) / AADL * AADH;
			var AADY = MY + (ADY - MY) / AADL * AADH;
			var BBDL = Sqrt(BRX - BX, BRY - BY);
			var BBDH = BBDL / 2.0;
			var BBDX = BX + (BRX - BX) / BBDL * BBDH;
			var BBDY = BY + (BRY - BY) / BBDL * BBDH;
			var AAL = Sqrt(ABDX - AADX, ABDY - AADY);
			var AAH = AAL / 2.0;
			var AAX = AADX + (ABDX - AADX) / AAL * AAH;
			var AAY = AADY + (ABDY - AADY) / AAL * AAH;
			var BBL = Sqrt(ABDX - BBDX, ABDY - BBDY);
			var BBH = BBL / 2.0;
			var BBX = BBDX + (ABDX - BBDX) / BBL * BBH;
			var BBY = BBDY + (ABDY - BBDY) / BBL * BBH;
			var ABL = Sqrt(BBX - AAX, BBY - AAY);
			var ABH = ABL / 2.0;
			var ABX = AAX + (BBX - AAX) / ABL * ABH;
			var ABY = AAY + (BBY - AAY) / ABL * ABH;
			var N = Sqrt(ABX - CX, ABY - CY);
			if (N < L) {
				HL += S; goto Next;
			} else if (N > L) {
				HL -= S;
				if (S > 0.00000000000000001) {
					S /= 2; HL += S;
					goto Next;
				}
			} else if (S > 0.00000000000000001) {
				S /= 2; HL += S; goto Next;
			}
			cmX = ADX;
			cmY = ADY;
			ceX = BRX;
			ceY = BRY;
			EX = BX;
			EY = BY;
			return HL / L;
		}
		#endregion
		#region #method# DCubic18(CX, CY, MX, MY, cmX, cmY, ceX, ceY, EX, EY) 
		public static void DCubic18(double CX, double CY, double MX, double MY, out double cmX, out double cmY, out double ceX, out double ceY, out double EX, out double EY) {
			var Arc180 = 4.0 / 3.0 * Mat.longTan(System.Math.PI / 16);
			var L = Sqrt(MX - CX, MY - CY); // Общая длина
			var T = L * Arc180;
			var BX = CY - MY + CX; // Поворот на 90 градусов по часовой стрелке
			var BY = MX - CX + CY; // Поворот на 90 градусов по часовой стрелке
			var DX = BY - CY + BX; // Поворот на 90 градусов по часовой стрелке
			var DY = CX - BX + BY; // Поворот на 90 градусов по часовой стрелке
			var HABL = Sqrt(BX - MX, BY - MY); // Получение длины от M до B
			var HABH = HABL / 2.0; // Центр квадрата
			var HABX = MX + (BX - MX) / HABL * HABH; // Координата центра квадрата по X
			var HABY = MY + (BY - MY) / HABL * HABH; // Координата центра квадрата по Y
			BX = CX + (HABX - CX) / HABH * L; // Смещение координаты от центра до края круга по X
			BY = CY + (HABY - CY) / HABH * L; // Смещение координаты от центра до края круга по X
			var RX = BY - CY + BX; // Поворот на 90 градусов по часовой стрелке
			var RY = CX - BX + BY; // Поворот на 90 градусов по часовой стрелке
			var ADX = MX + (DX - MX) / L * T; // Перемещение от MX до DX на половину длины
			var ADY = MY + (DY - MY) / L * T; // Перемещение от MY до DY на половину длины
			var BRX = BX + (RX - BX) / L * T; // Перемещение от BX до RX на половину длины
			var BRY = BY + (RY - BY) / L * T; // Перемещение от BY до RY на половину длины
			cmX = ADX;
			cmY = ADY;
			ceX = BRX;
			ceY = BRY;
			EX = BX;
			EY = BY;
		}
		#endregion
		#region #method# longTan(X) 
		public static double longTan(double X) {
			return longSin(X) / longCos(X);
		}
		#endregion
		#region #method# longSin(X) 
		public static double longSin(double X) {
			var Y = X;
			var I = 1;
			var J = false;
			var M = X * X;
			var R = Y;
			var A = M / ((I + 1) * (I + 2));
			while (Y >= 0.00000000000000001 || Y <= -0.00000000000000001) {
				R += ((J = !J) ? -1.0 : 1.0) * (Y *= A);
				I += 2;
				A = M / ((I + 1) * (I + 2));
			}
			return R;
		}
		#endregion
		#region #method# longCos(X) 
		public static double longCos(double X) {
			var I = 2;
			var A = 1.0;
			var M = X * X;
			var Y = M;
			var J = false;
			var P = 3;
			var F = 2.0;
			var R = A - Y * 1.0 / F;
			while ((A > R ? A - R : R - A) >= 0.00000000000000001) {
				while (P <= (2 * I)) { F *= P; P++; }
				A = R;
				R += ((J = !J) ? 1.0 : -1.0) * (Y *= M) / F;
				I++;
			}
			return R;
		}
		#endregion
		public static double Length(double MX, double MY, ref double EX, ref double EY, double SL) {
			var L = Mat.Sqrt(MX - EX, MY - EY);
			EX = MX + (EX - MX) / L * SL;
			EY = MY + (EY - MY) / L * SL;
			return L;
		}
	}
}
