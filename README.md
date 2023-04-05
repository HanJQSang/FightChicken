## 本项目遵循"GNU 通用公共许可证协议 v3"(即GPL-3.0)
### 协议要求的:
- 修改后的源码也需要公开
- 版权及协议也要于此协议一致
- 修改后需要在相应的文件做说明
### 协议允许的:
- 商用，分发，修改，专利授权，私用
### 协议禁止的:
- 因使用等造成影响责任承担、也就是说免责申明
- 在软件分发传播过程中附加上原来没有的协议条款等
### 详细内容请查看[LICENSE](https://github.com/Qiumy-bilibili/FightChicken/blob/main/LICENSE)
---
# 开发
## 开发环境
- 客户端:Unity 2021.3.16f1c1 & C#
- 服务端:易语言 5.9
## 注意事项
- Game : 客户端项目文件
- Server : 服务端项目文件
- 首次打开项目文件可能耗时较长，请耐心等待
## 各 C# Script 作用
- Connect.cs : 与服务器连接 & 通信
- ServerSettings.cs : 记录服务器IP & 端口变量(均为文本型(string))
- LoadScene.cs : 场景跳转
- Lobby/WaitServer.cs : 计时(小数型(float)变量 += 时间(Time.deltaTime))以关闭提示组件(GameObject)
- Main/Biu.cs : 子弹向前匀速直线运动 & 删除
- Main/CountTime.cs : 游戏时间计时
- Main/EndNow.cs : 更改 Main/CountTime.cs 内的 Time_Now 至游戏结束时间
- Main/ESCCancel.cs : 游戏菜单的打开 & 关闭
- Main/FightMyself.cs : Player 自身碰到 NPC 的扣分处理
- Main/GoDead.cs : NPC 碰到子弹(Bullet)的扣血处理
- Main/GunShoot.cs : 子弹发射
- Main/InXWall.cs : 判断 Player 是否在左/右的墙里(外)
- Main/InYWall.cs : 判断 Player 是否在上/下的墙里(外)
- Main/NPCFind.cs : NPC 向 Player 移动
- Main/Player_ToMouse.cs : 枪朝鼠标位置
- Main/PlayerMove.cs : Player 移动
- Main/Redo.cs : 再次进入时进行重置(分数(WritePoint.Point) & 时间(CountTime.Time_Now))
- Main/RenovateInfo.cs : 刷新 UI(分数 & 时间)
- Main/Spawn.cs : 计时以生成 NPC
- Main/WritePoint.cs : 记录分数(整数型(int))
## 客户端与服务端的通讯与处理结构
![running](https://github.com/Qiumy-bilibili/FightChicken/blob/main/github/running.png)
## 关于二次创作
- 二创作品可发布至 github/gitee 上
- 二创作品可发送至 bilibiliqiumy@outlook.com 而不发布至 github/gitee 上
# 问题反馈
可以将你的问题发送至 bilibiliqiumy@outlook.com ，看到后会尽快解答
