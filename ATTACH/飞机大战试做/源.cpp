#include<iostream>;
#include<string>;
#include<conio.h>;
#include<graphics.h>;
#include<mmsystem.h>;
//win32多媒体设备接口
#include<ctime>;
#pragma comment(lib,"winmm.lib")
#define WIN_WIDTH 591;
#define WIN_HEIGHT 864;
using namespace std;
IMAGE background(591,864);
IMAGE player;
IMAGE shoot;
IMAGE enemy;
class plane {
public:
	plane() :x_p(300), y_p(664), dx_p(10), dy_p(10) ,flag(true){};
	int x_p;
	int y_p;
	int dx_p;
	int dy_p;
	bool flag;
};
int score = 0;
DWORD t1, t2 = 0;
plane we;
plane bullet;
plane bullet_2;
plane bullet_3;
plane bullet_4;
plane ENEMY[10];
void GameInt() {
	mciSendString("open ./使用的贴图/背景音乐.mp3 alias BGM",0,0,0);//向多媒体设备接口发送字符串
	mciSendString("play BGM repeat ", 0, 0, 0);
	we.flag = true;
	for (int i = 0; i < 5; i++) {
		bullet.flag = false;
		bullet.x_p = 0;
		bullet.y_p = 0;
		bullet_2.flag = false;
		bullet_2.x_p = 0;
		bullet_2.y_p = 0;
		bullet.dy_p = bullet_2.dy_p = 20;
	}
	for (int i = 0; i < 10; i++) {
		int n = rand() % 10 + 1;
		ENEMY[i].x_p = 75 * n;
		ENEMY[i].y_p = 0;
		ENEMY[i].dy_p = 7;
		ENEMY[i].flag = true;
	}
	t1 = t2 = GetTickCount();
}
void CreateEnemy() {
	loadimage(&enemy, "./使用的贴图/地方飞机.png", 75, 100);
	for (int i = 0; i < 10; i++) {
		if (ENEMY[i].flag == true) {
			putimage(ENEMY[i].x_p, ENEMY[i].y_p, &enemy);
		}
	}
}
void EnemyMove() {
	for (int i = 0; i < 10; i++) {
		if (ENEMY[i].flag == true) {
			ENEMY[i].y_p += ENEMY[i].dy_p;
		}
		if (ENEMY[i].y_p > 864-100) {
			ENEMY[i].flag = false;
		}
	}
}
void CreateBullet() {
	loadimage(&shoot, "./使用的贴图/子弹.png");
	for (int u = 0; u < 5; u++) {
		if (bullet.flag == false) {
			bullet.flag = true;
			bullet.x_p = we.x_p + 20;
			bullet.y_p = we.y_p + 29;
	}
		if (bullet_2.flag == false) {
			bullet_2.flag = true;
			bullet_2.x_p = we.x_p + 100;
			bullet_2.y_p = we.y_p + 29;
		}
		else {
			bullet.flag = true;
		}
		bullet_3 = bullet;
		bullet_4 = bullet_2;
		putimage(bullet.x_p, bullet.y_p, &shoot);
		putimage(bullet_2.x_p, bullet_2.y_p, &shoot);
		if (t2 - t1 > 100) {
			putimage(bullet.x_p, bullet.y_p, &shoot);
			putimage(bullet_2.x_p, bullet_2.y_p, &shoot);
		}
	}
}
void DestroyEnemy() {
	
	for (int i = 0; i < 10; i++) {
		for (int j = 0; j < 5; j++) {
			if (bullet.flag == true) {
				if (bullet.y_p - ENEMY[i].y_p <150) {
					ENEMY[i].flag = false;
					bullet.flag = false;
				}
			}
		}
		if (bullet.flag == false && ENEMY[i].flag == false) {
			score += 50; 
		}
	}
}
void BulletMove(int s) {
	for (int i = 0; i < 5; i++) {
		if (bullet.flag == true) {
			bullet.y_p -= s;
		}
		if (bullet.y_p <= 0) {
			bullet.flag = false;
		}
		if (bullet_2.flag == true) {
			bullet_2.y_p -= s;
		}
		if (bullet_2.y_p <= 0) {
			bullet_2.flag = false;
		}
		if (bullet_3.flag == true) {
			bullet_3.y_p -= s;
		}
		if (bullet_3.y_p <= 0) {
			bullet_3.flag = false;
		}
		if (bullet_4.flag == true) {
			bullet_4.y_p -= s;
		}
		if (bullet_4.y_p <= 0) {
			bullet_4.flag = false;
		}
	}
}
void GameMove() {
	cleardevice();
	loadimage(&background, "./使用的贴图/太空背景.jpeg");
	putimage(0, 0, &background);
	loadimage(&player, "./使用的贴图/我方飞机.png", 150, 100);
	putimage(we.x_p, we.y_p, &player);
	if (GetAsyncKeyState('W') && we.y_p >= 0) {
		we.y_p -= we.dy_p;
	}
	if (GetAsyncKeyState('S') && we.y_p <= 864 - 150) {
		we.y_p += we.dy_p;
	}
	if (GetAsyncKeyState('A') && we.x_p >= 0) {
		we.x_p -= we.dx_p;
	}
	if (GetAsyncKeyState('D') && we.x_p <= 591 - 150) {
		we.x_p += we.dx_p;
	}
	if (GetAsyncKeyState(' ') && t2 - t1 > 100) {
		CreateBullet();
		DestroyEnemy();
	}
	t2 = GetTickCount();
	BulletMove(5);
}
void grade() {
	char num[20];
	setfillcolor(YELLOW);
	solidrectangle(0, 0, 100, 50);
	settextstyle(30,0, "宋体");
	sprintf(num, "%d", score);
	outtextxy(30,20,num);
}
//int GameLose() {
//	if (we.y_p - ENEMY[].y_p < 75 && ((we.x_p - ENEMY.x_p<200 || ENEMY.x_p - we.x_p<200) == 1)) {
//		HWND hwnd = GetForegroundWindow();
//		int isok = MessageBox(hwnd, "游戏结束！！", "很遗憾：", MB_OKCANCEL);
//		if (isok == IDOK) {
//			return 0;
//		}
//		if (isok == IDCANCEL) {
//			return 0;
//		}
//		else {
//			return 1;
//		}
//
//
//	}
//}
int GameLose() {
	for (int i = 0; i < 10; i++) {
		if (abs(ENEMY[i].y_p - we.y_p) < 75 && abs(ENEMY[i].x_p - we.x_p) < 150) {
			HWND hwnd = GetForegroundWindow();
					int isok = MessageBox(hwnd, "游戏结束！！您的分数如图表所示", "很遗憾：", MB_OKCANCEL);
					if (isok == IDOK) {
						return 0;
					}
					if (isok == IDCANCEL) {
						return 0;
					}
					else {
						return 1;
					}
			return 0;
		}
		else {
			return 10086;
		}
	}
}
void BulletDraw() {
	for (int i = 0; i < 5; i=i++) {
			if (bullet.flag == true) {
				putimage(bullet.x_p, bullet.y_p, &shoot);
			}
			if (bullet_2.flag == true) {
				putimage(bullet_2.x_p, bullet_2.y_p, &shoot);
			}
			if (bullet_3.flag == true) {
				putimage(bullet_3.x_p, bullet.y_p, &shoot);
			}
			if (bullet_4.flag == true) {
				putimage(bullet_4.x_p, bullet_4.y_p, &shoot);
			}
	}
}
int main() {
	srand((unsigned)int(NULL));
	initgraph(591, 864);
	cleardevice();
	FLAG:
	GameInt();
	BeginBatchDraw();
	while (1) {
		GameMove();
		CreateEnemy();
		BulletDraw();
		EnemyMove();
		grade();
		FlushBatchDraw();
		int num = 0;
		for (int i = 0; i < 10; i++) {
			if (ENEMY[i].flag == false) {
				num++;
			}
			else {
				num = num;
			}
		}
		if (num > 5) {
			goto FLAG;
		}
		if (GameLose() == 0) {
			return 0;
		}
		
	}
	EndBatchDraw();
	system("pause");
	return 0;
}