#include<iostream>;
#include<graphics.h>;
#include<conio.h>;
#include<string>;
using namespace std;
int arr[601][601];
void title() {
	HWND title = GetForegroundWindow();
	SetWindowText(title, "井字棋小游戏");
	MessageBox(title, "是否开始游戏？", "警告", MB_OKCANCEL);
}
void draw_circle(int x, int y, int r) {
	circle(x, y, r);
	arr[x][y] = 1;
}
void draw_x(int x, int y) {
	line(x - 100, y - 100, x + 100, y + 100);
	line(x - 100, y + 100, x + 100, y - 100);
	arr[x][y] = 2;
}
int  x_win(int x,int y) {
	if (arr[x][y] == 2 && arr[x - 200][y] == 2 && arr[x - 400][y] == 2) {
		return 1;
	}
	if (arr[x][y] == 2 && arr[x + 200][y] == 2 && arr[x + 400][y] == 2) {
		return 1;
	}
	if (arr[x][y] == 2 && arr[x - 200][y] == 2 && arr[x + 200][y] == 2) {
		return 1;
	}
	if (arr[x][y] == 2 && arr[x][y-200] == 2 && arr[x][y-400] == 2) {
		return 1;
	}
	if (arr[x][y] == 2 && arr[x][y+200] == 2 && arr[x][y+400] == 2) {
		return 1;
	}
	if (arr[x][y] == 2 && arr[x][y-200] == 2 && arr[x][y+200] == 2) {
		return 1;
	}
	if (arr[x][y] == 2 && arr[x - 200][y - 200] == 2 && arr[x - 400][y - 400] == 2) {
		return 1;
	}
	if (arr[x][y] == 2 && arr[x - 200][y - 200] == 2 && arr[x +200][y +200] == 2) {
		return 1;
	}
	if (arr[x][y] == 2 && arr[x + 200][y + 200] == 2 && arr[x + 400][y + 400] == 2) {
		return 1;
	}
	if (arr[x][y] == 2 && arr[x - 200][y + 200] == 2 && arr[x - 400][y + 400] == 2) {
		return 1;
	}
	if (arr[x][y] == 2 && arr[x - 200][y + 200] == 2 && arr[x + 200][y - 200] == 2) {
		return 1;
	}
	if (arr[x][y] == 2 && arr[x + 200][y - 200] == 2 && arr[x + 400][y - 400] == 2) {
		return 1;
	}
	else {
		return 0;
	}
}
int  o_win(int x,int y) {
		if (arr[x][y] == 1 && arr[x - 200][y] == 1 && arr[x - 400][y] == 1) {
			return 1;
		}
		if (arr[x][y] == 1 && arr[x + 200][y] == 1 && arr[x + 400][y] == 1) {
			return 1;
		}
		if (arr[x][y] == 1 && arr[x - 200][y] == 1 && arr[x + 200][y] == 1) {
			return 1;
		}
		if (arr[x][y] == 1 && arr[x][y - 200] == 1 && arr[x][y - 400] == 1) {
			return 1;
		}
		if (arr[x][y] == 1 && arr[x][y + 200] == 1 && arr[x][y + 400] == 1) {
			return 1;
		}
		if (arr[x][y] == 1 && arr[x][y - 200] == 1 && arr[x][y + 200] == 1) {
			return 1;
		}
		if (arr[x][y] == 1 && arr[x - 200][y - 200] == 1 && arr[x - 400][y - 400] == 1) {
			return 1;
		}
		if (arr[x][y] == 1 && arr[x - 200][y - 200] == 1 && arr[x + 200][y + 200] == 1) {
			return 1;
		}
		if (arr[x][y] == 1 && arr[x + 200][y + 200] == 1 && arr[x + 400][y + 400] == 1) {
			return 1;
		}
		if (arr[x][y] == 1 && arr[x - 200][y + 200] == 1 && arr[x - 400][y + 400] == 1) {
			return 1;
		}
		if (arr[x][y] == 1 && arr[x - 200][y + 200] == 1 && arr[x + 200][y - 200] == 1) {
			return 1;
		}
		if (arr[x][y] == 1 && arr[x + 200][y - 200] == 1 && arr[x + 400][y - 400] == 1) {
			return 1;
		}
	}
void x_title() {
	HWND hwnd = GetForegroundWindow();
	MessageBox(hwnd, "恭喜X获胜", "游戏结束", MB_OKCANCEL);
}
void o_title() {
	HWND hwnd = GetForegroundWindow();
	MessageBox(hwnd, "恭喜O获胜", "游戏结束", MB_OKCANCEL);
}
int main() {
	for (int i = 0; i < 601; i++) {
		for (int j = 0; j < 601; j++) {
			arr[i][j] = 100;
		}
	}
	title();
	int num = 1;
	initgraph(600,600);
	setbkcolor(BLACK);
	cleardevice();
	for (int i = 0; i <= 600; i += 200) {
		line(0, i, 600, i);
		line(i, 0, i, 600);
	}
	while (1) {
		if (MouseHit()) {
			MOUSEMSG msg = GetMouseMsg();
			switch (msg.uMsg) {
			case(WM_LBUTTONDOWN):
				/*if (msg.x <= 200) {
					msg.x = 100;
				}
				if (msg.y <= 200) {
					msg.y = 100;
				}*/
				msg.x = (msg.x / 200) * 200 + 100;
				msg.y = (msg.y / 200) * 200 + 100;
				if (num % 2 != 0) {
					draw_circle(msg.x, msg.y, 100);
					num++;
					break;
				}
				if (num % 2 == 0) {
					draw_x(msg.x, msg.y);
					num++;
					break;
				}
			}
			if (x_win(msg.x,msg.y) == 1) {
				x_title();
				break;
			}
			if (o_win(msg.x, msg.y) == 1) {
				o_title();
				break;
			}
		}
	}
	system("pause");
	return 0;
}