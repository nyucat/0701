#include<iostream>;
#include<graphics.h>;
#include<string>;
#include<conio.h>;
#include<ctime>;
using namespace std;
class button {
public:
	int x1;
	int y1;
	int x2;
	int y2;
	char text[];
	button(int n_x1, int n_y1, int n_x2, int n_y2) :x1(n_x1), x2(n_x2), y1(n_y1), y2(n_y2) {
		setfillcolor(BROWN);
		solidrectangle(x1, y1, x2, y2);
	}
};
void begin() {

}
int change() {
	//获取窗口句柄
	HWND hwnd = GetForegroundWindow();
	//设置窗口标题
	SetWindowText(hwnd, "C++制作的简单五子棋小游戏，欢迎试玩");
	//设置提示用户操作的弹窗
	int isok=MessageBox(hwnd, "是否要开始游戏？", "警告！！！！", MB_OKCANCEL);
	if (isok == IDOK) {
		return 1;
	}
	if (isok == IDCANCEL) {
		return 0;
	}

}
void black_win() {
	//获取窗口句柄
	HWND hwnd = GetForegroundWindow();
	//设置提示用户操作的弹窗
	MessageBox(hwnd, "恭喜！！黑棋获胜", "游戏结束", MB_OKCANCEL);
}
void white_win() {
	//获取窗口句柄
	HWND hwnd = GetForegroundWindow();
	//设置提示用户操作的弹窗
	MessageBox(hwnd, "恭喜！！白棋获胜", "游戏结束", MB_OKCANCEL);

}

int arr[800][800];

unsigned int if_black_win(MOUSEMSG&msg) {
	if (arr[msg.x][msg.y] == 1 && arr[msg.x][msg.y + 40] == 1 && arr[msg.x][msg.y + 80] == 1 && arr[msg.x][msg.y + 120] == 1 && arr[msg.x][msg.y + 160] == 1)
	{
		return 1;
	}
	else if (arr[msg.x][msg.y - 40] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x][msg.y + 40] == 1 && arr[msg.x][msg.y + 80] == 1 && arr[msg.x][msg.y + 120] == 1)
	{
		return 1;
	}
	else if (arr[msg.x][msg.y - 80] == 1 && arr[msg.x][msg.y - 40] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x][msg.y + 40] == 1 && arr[msg.x][msg.y + 80] == 1)
	{
		return 1;
	}
	else if (arr[msg.x][msg.y - 120] == 1 && arr[msg.x][msg.y - 80] == 1 && arr[msg.x][msg.y-40] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x][msg.y + 40] == 1)
	{
		return 1;
	}
	else if (arr[msg.x][msg.y - 160] == 1 && arr[msg.x][msg.y - 120] == 1 && arr[msg.x][msg.y-80] == 1 && arr[msg.x][msg.y-40] == 1 && arr[msg.x][msg.y] == 1)
	{
		return 1;
	}
	else if (arr[msg.x][msg.y] == 1 && arr[msg.x+40][msg.y] == 1 && arr[msg.x+80][msg.y] == 1 && arr[msg.x+120][msg.y] == 1 && arr[msg.x+160][msg.y ] == 1)
	{
		return 1;
	}
	else if (arr[msg.x-40][msg.y] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x+40][msg.y] == 1 && arr[msg.x+80][msg.y] == 1 && arr[msg.x+120][msg.y] == 1)
	{
		return 1;
	}
	else if (arr[msg.x-80][msg.y] == 1 && arr[msg.x-40][msg.y] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x+40][msg.y] == 1 && arr[msg.x+80][msg.y] == 1)
	{
		return 1;
	}
	else if (arr[msg.x-120][msg.y] == 1 && arr[msg.x-80][msg.y] == 1 && arr[msg.x-40][msg.y] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x+40][msg.y] == 1)
	{
		return 1;
	}
	else if (arr[msg.x-160][msg.y] == 1 && arr[msg.x-120][msg.y] == 1 && arr[msg.x-80][msg.y] == 1 && arr[msg.x-40][msg.y] == 1 && arr[msg.x][msg.y] == 1)
	{
		return 1;
	}
	else if (arr[msg.x][msg.y] == 1 && arr[msg.x+40][msg.y + 40] == 1 && arr[msg.x+80][msg.y + 80] == 1 && arr[msg.x+120][msg.y + 120] == 1 && arr[msg.x+160][msg.y + 160] == 1)
	{
		return 1;
	}
	else if (arr[msg.x-40][msg.y - 40] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x+40][msg.y + 40] == 1 && arr[msg.x+80][msg.y + 80] == 1 && arr[msg.x+120][msg.y + 120] == 1)
	{
		return 1;
	}
	else if (arr[msg.x-80][msg.y - 80] == 1 && arr[msg.x-40][msg.y - 40] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x+40][msg.y + 40] == 1 && arr[msg.x+80][msg.y + 80] == 1)
	{
		return 1;
	}
	else if (arr[msg.x-120][msg.y - 120] == 1 && arr[msg.x-80][msg.y - 80] == 1 && arr[msg.x-40][msg.y-40] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x+40][msg.y + 40] == 1)
	{
		return 1;
	}
	else if (arr[msg.x-160][msg.y - 160] == 1 && arr[msg.x-120][msg.y - 120] == 1 && arr[msg.x-80][msg.y-80] == 1 && arr[msg.x-40][msg.y-40] == 1 && arr[msg.x][msg.y] == 1)
	{
		return 1;
	}
	else if (arr[msg.x][msg.y] == 1 && arr[msg.x + 40][msg.y - 40] == 1 && arr[msg.x + 80][msg.y - 80] == 1 && arr[msg.x + 120][msg.y - 120] == 1 && arr[msg.x + 160][msg.y - 160] == 1)
	{
		return 1;
	}
	else if (arr[msg.x - 40][msg.y + 40] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x + 40][msg.y - 40] == 1 && arr[msg.x + 80][msg.y - 80] == 1 && arr[msg.x + 120][msg.y - 120] == 1)
	{
		return 1;
	}
	else if (arr[msg.x - 80][msg.y + 80] == 1 && arr[msg.x - 40][msg.y + 40] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x + 40][msg.y - 40] == 1 && arr[msg.x + 80][msg.y - 80] == 1)
	{
		return 1;
	}
	else if (arr[msg.x - 120][msg.y + 120] == 1 && arr[msg.x - 80][msg.y + 80] == 1 && arr[msg.x - 40][msg.y + 40] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x + 40][msg.y - 40] == 1)
	{
		return 1;
	}
	else if (arr[msg.x - 160][msg.y + 160] == 1 && arr[msg.x - 120][msg.y + 120] == 1 && arr[msg.x - 80][msg.y + 80] == 1 && arr[msg.x - 40][msg.y + 40] == 1 && arr[msg.x][msg.y] == 1)
	{
		return 1;
	}
	else if (arr[msg.x][msg.y] == 1 && arr[msg.x - 40][msg.y + 40] == 1 && arr[msg.x - 80][msg.y + 80] == 1 && arr[msg.x - 120][msg.y + 120] == 1 && arr[msg.x - 160][msg.y + 160] == 1)
	{
		return 1;
	}
	else if (arr[msg.x + 40][msg.y - 40] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x - 40][msg.y + 40] == 1 && arr[msg.x - 80][msg.y + 80] == 1 && arr[msg.x - 120][msg.y + 120] == 1)
	{
		return 1;
	}
	else if (arr[msg.x + 80][msg.y - 80] == 1 && arr[msg.x + 40][msg.y - 40] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x - 40][msg.y + 40] == 1 && arr[msg.x - 80][msg.y + 80] == 1)
	{
		return 1;
	}
	else if (arr[msg.x + 120][msg.y - 120] == 1 && arr[msg.x + 80][msg.y - 80] == 1 && arr[msg.x + 40][msg.y - 40] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x - 40][msg.y + 40] == 1)
	{
		return 1;
	}
	else if (arr[msg.x + 160][msg.y - 160] == 1 && arr[msg.x + 120][msg.y - 120] == 1 && arr[msg.x + 80][msg.y - 80] == 1 && arr[msg.x + 40][msg.y - 40] == 1 && arr[msg.x][msg.y] == 1)
	{
		return 1;
	}
	else if (arr[msg.x][msg.y] == 1 && arr[msg.x - 40][msg.y - 40] == 1 && arr[msg.x - 80][msg.y - 80] == 1 && arr[msg.x - 120][msg.y - 120] == 1 && arr[msg.x - 160][msg.y - 160] == 1)
	{
		return 1;
	}
	else if (arr[msg.x + 40][msg.y + 40] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x - 40][msg.y - 40] == 1 && arr[msg.x - 80][msg.y - 80] == 1 && arr[msg.x - 120][msg.y - 120] == 1)
	{
		return 1;
	}
	else if (arr[msg.x + 80][msg.y + 80] == 1 && arr[msg.x + 40][msg.y + 40] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x - 40][msg.y - 40] == 1 && arr[msg.x - 80][msg.y - 80] == 1)
	{
		return 1;
	}
	else if (arr[msg.x + 120][msg.y + 120] == 1 && arr[msg.x + 80][msg.y + 80] == 1 && arr[msg.x + 40][msg.y + 40] == 1 && arr[msg.x][msg.y] == 1 && arr[msg.x - 40][msg.y - 40] == 1)
	{
		return 1;
	}
	else if (arr[msg.x + 160][msg.y + 160] == 1 && arr[msg.x + 120][msg.y + 120] == 1 && arr[msg.x + 80][msg.y + 80] == 1 && arr[msg.x + 40][msg.y + 40] == 1 && arr[msg.x][msg.y] == 1)
	{
		return 1;
	}
	else {
		return 0;
	}

}

unsigned int if_white_win(MOUSEMSG& msg) {
	if (arr[msg.x][msg.y] == 2 && arr[msg.x][msg.y + 40] == 2 && arr[msg.x][msg.y + 80] == 2 && arr[msg.x][msg.y + 120] == 2 && arr[msg.x][msg.y + 160] == 2)
	{
		return 2;
	}
	else if (arr[msg.x][msg.y - 40] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x][msg.y + 40] == 2 && arr[msg.x][msg.y + 80] == 2 && arr[msg.x][msg.y + 120] == 2)
	{
		return 2;
	}
	else if (arr[msg.x][msg.y - 80] == 2 && arr[msg.x][msg.y - 40] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x][msg.y + 40] == 2 && arr[msg.x][msg.y + 80] == 2)
	{
		return 2;
	}
	else if (arr[msg.x][msg.y - 120] == 2 && arr[msg.x][msg.y - 80] == 2 && arr[msg.x][msg.y - 40] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x][msg.y + 40] == 2)
	{
		return 2;
	}
	else if (arr[msg.x][msg.y - 160] == 2 && arr[msg.x][msg.y - 120] == 2 && arr[msg.x][msg.y - 80] == 2 && arr[msg.x][msg.y - 40] == 2 && arr[msg.x][msg.y] == 2)
	{
		return 2;
	}
	else if (arr[msg.x][msg.y] == 2 && arr[msg.x + 40][msg.y] == 2 && arr[msg.x + 80][msg.y] == 2 && arr[msg.x + 120][msg.y] == 2 && arr[msg.x + 160][msg.y] == 2)
	{
		return 2;
	}
	else if (arr[msg.x - 40][msg.y] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x + 40][msg.y] == 2 && arr[msg.x + 80][msg.y] == 2 && arr[msg.x + 120][msg.y] == 2)
	{
		return 2;
	}
	else if (arr[msg.x - 80][msg.y] == 2 && arr[msg.x - 40][msg.y] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x + 40][msg.y] == 2 && arr[msg.x + 80][msg.y] == 2)
	{
		return 2;
	}
	else if (arr[msg.x - 120][msg.y] == 2 && arr[msg.x - 80][msg.y] == 2 && arr[msg.x - 40][msg.y] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x + 40][msg.y] == 2)
	{
		return 2;
	}
	else if (arr[msg.x - 160][msg.y] == 2 && arr[msg.x - 120][msg.y] == 2 && arr[msg.x - 80][msg.y] == 2 && arr[msg.x - 40][msg.y] == 2 && arr[msg.x][msg.y] == 2)
	{
		return 2;
	}
	else if (arr[msg.x][msg.y] == 2 && arr[msg.x + 40][msg.y + 40] == 2 && arr[msg.x + 80][msg.y + 80] == 2 && arr[msg.x + 120][msg.y + 120] == 2 && arr[msg.x + 160][msg.y + 160] == 2)
	{
		return 2;
	}
	else if (arr[msg.x - 40][msg.y - 40] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x + 40][msg.y + 40] == 2 && arr[msg.x + 80][msg.y + 80] == 2 && arr[msg.x + 120][msg.y + 120] == 2)
	{
		return 2;
	}
	else if (arr[msg.x - 80][msg.y - 80] == 2 && arr[msg.x - 40][msg.y - 40] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x + 40][msg.y + 40] == 2 && arr[msg.x + 80][msg.y + 80] == 2)
	{
		return 2;
	}
	else if (arr[msg.x - 120][msg.y - 120] == 2 && arr[msg.x - 80][msg.y - 80] == 2 && arr[msg.x - 40][msg.y - 40] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x + 40][msg.y + 40] == 2)
	{
		return 2;
	}
	else if (arr[msg.x - 160][msg.y - 160] == 2 && arr[msg.x - 120][msg.y - 120] == 2 && arr[msg.x - 80][msg.y - 80] == 2 && arr[msg.x - 40][msg.y - 40] == 2 && arr[msg.x][msg.y] == 2)
	{
		return 2;
	}
	else if (arr[msg.x][msg.y] == 2 && arr[msg.x + 40][msg.y - 40] == 2 && arr[msg.x + 80][msg.y - 80] == 2 && arr[msg.x + 120][msg.y - 120] == 2 && arr[msg.x + 160][msg.y - 160] == 2)
	{
		return 2;
	}
	else if (arr[msg.x - 40][msg.y + 40] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x + 40][msg.y - 40] == 2 && arr[msg.x + 80][msg.y - 80] == 2 && arr[msg.x + 120][msg.y - 120] == 2)
	{
		return 2;
	}
	else if (arr[msg.x - 80][msg.y + 80] == 2 && arr[msg.x - 40][msg.y + 40] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x + 40][msg.y - 40] == 2 && arr[msg.x + 80][msg.y - 80] == 2)
	{
		return 2;
	}
	else if (arr[msg.x - 120][msg.y + 120] == 2 && arr[msg.x - 80][msg.y + 80] == 2 && arr[msg.x - 40][msg.y + 40] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x + 40][msg.y - 40] == 2)
	{
		return 2;
	}
	else if (arr[msg.x - 160][msg.y + 160] == 2 && arr[msg.x - 120][msg.y + 120] == 2 && arr[msg.x - 80][msg.y + 80] == 2 && arr[msg.x - 40][msg.y + 40] == 2 && arr[msg.x][msg.y] == 2)
	{
		return 2;
	}
	else if (arr[msg.x][msg.y] == 2 && arr[msg.x - 40][msg.y + 40] == 2 && arr[msg.x - 80][msg.y + 80] == 2 && arr[msg.x - 120][msg.y + 120] == 2 && arr[msg.x - 160][msg.y + 160] == 2)
	{
		return 2;
	}
	else if (arr[msg.x + 40][msg.y - 40] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x - 40][msg.y + 40] == 2 && arr[msg.x - 80][msg.y + 80] == 2 && arr[msg.x - 120][msg.y + 120] == 2)
	{
		return 2;
	}
	else if (arr[msg.x + 80][msg.y - 80] == 2 && arr[msg.x + 40][msg.y - 40] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x - 40][msg.y + 40] == 2 && arr[msg.x - 80][msg.y + 80] == 2)
	{
		return 2;
	}
	else if (arr[msg.x + 120][msg.y - 120] == 2 && arr[msg.x + 80][msg.y - 80] == 2 && arr[msg.x + 40][msg.y - 40] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x - 40][msg.y + 40] == 2)
	{
		return 2;
	}
	else if (arr[msg.x + 160][msg.y - 160] == 2 && arr[msg.x + 120][msg.y - 120] == 2 && arr[msg.x + 80][msg.y - 80] == 2 && arr[msg.x + 40][msg.y - 40] == 2 && arr[msg.x][msg.y] == 2)
	{
		return 2;
	}
	else if (arr[msg.x][msg.y] == 2 && arr[msg.x - 40][msg.y - 40] == 2 && arr[msg.x - 80][msg.y - 80] == 2 && arr[msg.x - 120][msg.y - 120] == 2 && arr[msg.x - 160][msg.y - 160] == 2)
	{
		return 2;
	}
	else if (arr[msg.x + 40][msg.y + 40] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x - 40][msg.y - 40] == 2 && arr[msg.x - 80][msg.y - 80] == 2 && arr[msg.x - 120][msg.y - 120] == 2)
	{
		return 2;
	}
	else if (arr[msg.x + 80][msg.y + 80] == 2 && arr[msg.x + 40][msg.y + 40] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x - 40][msg.y - 40] == 2 && arr[msg.x - 80][msg.y - 80] == 2)
	{
		return 2;
	}
	else if (arr[msg.x + 120][msg.y + 120] == 2 && arr[msg.x + 80][msg.y + 80] == 2 && arr[msg.x + 40][msg.y + 40] == 2 && arr[msg.x][msg.y] == 2 && arr[msg.x - 40][msg.y - 40] == 2)
	{
		return 2;
	}
	else if (arr[msg.x + 160][msg.y + 160] == 2 && arr[msg.x + 120][msg.y + 120] == 2 && arr[msg.x + 80][msg.y + 80] == 2 && arr[msg.x + 40][msg.y + 40] == 2 && arr[msg.x][msg.y] == 2)
	{
		return 2;
	}
	else {
		return 0;
	}

}

void draw_circle(MOUSEMSG &msg,int num) {
	if (num % 2 == 1) {
		setfillcolor(BLACK);
		arr[msg.x][msg.y] = 1;
	}
	if (num % 2 == 0) {
		setfillcolor(WHITE);
		arr[msg.x][msg.y] = 2;
	}
	solidcircle(msg.x, msg.y, 15);
}
int menu() {
	initgraph(800, 800);
	setbkcolor(BROWN);
	cleardevice();
	setbkcolor(BROWN);
	settextcolor(RED);
	settextstyle(75, 0, "宋体");
	int width_1 = textwidth("五子棋");
	int height_1 = textheight("五子棋");
	outtextxy(400 - width_1 / 2, height_1 / 2 + 50, "五子棋");
	settextstyle(100, 0, "宋体");
	int width_2 = textwidth("Game Start");
	int height_2 = textheight("Game Start");
	button b1(400 - width_2 / 2, height_1 + 200, 400 + width_2 / 2, height_2 + 300 + height_1);
	outtextxy(400 - width_2 / 2, height_1 + 200, "Game Start");
	int width_3 = textwidth("Escape");
	int height_3 = textheight("Escape");
	outtextxy(400 - width_3 / 2, height_2 + height_1 + 350, "Escape");
	MOUSEMSG msg = GetMouseMsg();
	if (MouseHit()) {
		switch (msg.uMsg) {
		case(WM_LBUTTONDOWN): {
			if (msg.x > 400 - width_2 / 2 && msg.x< 400 + width_2 / 2 && msg.y>height_1 + 200 && msg.y < height_2 + 200 + height_1) {
				return 1;
			}
			else if (msg.x > 400 - width_3 && msg.x<400 + width_3 && msg.y>height_1 + 350 && msg.y < height_1 + height_3 + 350) {
				return 0;
			}
			else {
				return 3;
			}}
		case(WM_RBUTTONDOWN):
			return 2;
			break;
		}
	}
}
int main() {
	menu();
	int num = 1;
	for (int i = 0; i < 800; i++) {
		for (int j = 0; j < 800; j++) {
			arr[i][j] = 0;
		}
	}
	initgraph(800, 800);
	setbkcolor(BROWN);
	cleardevice();
	if (change() == 0) {
		return 0;
	}
	if (menu == 0) {
		return 0;
	}

	for (int i = 0; i <= 800; i += 40) {
		line(i, 0, i, 800);
		line(0, i, 800, i);
	}
	while (1) {
		if (MouseHit()) {
			MOUSEMSG msg = GetMouseMsg();
			switch (msg.uMsg) {
			case(WM_LBUTTONDOWN):
				if (msg.x % 40 >= 20) {
					msg.x = ((msg.x / 40) + 1) * 40;
				}
				if (msg.x % 40 < 20) {
					msg.x = (msg.x / 40) * 40;
				}
				if (msg.y % 40 >= 20) {
					msg.y = ((msg.y / 40) + 1) * 40;
				}
				if (msg.y % 40 < 20) {
					msg.y = (msg.y / 40) * 40;
				}
				draw_circle(msg,num);
				num++;
				break;
			case(WM_RBUTTONDOWN):
				break;
			}
			if (if_black_win(msg) == 1) {
				black_win();
				return 0;
			}
			if (if_white_win(msg) == 2) {
				white_win();
				return 0;
			}
		}
	}
	system("pause");
	return 0;
}