# ASPNET_Equipment_Management
asp.net基于三层模式实验室仪器设备管理系统毕业源码案例设计
## 开发技术：基于MVC思想和三层设计模式，前台采用bootstrap响应式框架，后台div+css
## 程序开发软件: Visual Studio 2010以上    数据库：sqlserver2005以上
### 实验室设备仪器管理系统分为四个模块实验室登陆模块、学生模块、教师模块、管理员模块。
1、登陆模块：主要提供用户注册和登陆

2、学生模块：可实现对实验课仪器设备的信息查询、借领仪器耗材、设备事故的登记等。

3、管理员模块：实验室设备信息查询：实现设备仪器信息的查询和统计。

4、设备事故记录：实现设备仪器事故上报、设备事件维修、设备事故更新。

5、设备资料管理：实现设备仪器操作指南的查询和更新。

6、设备损坏管理：实现设备仪器损坏信息的查询和更新。

7、设备耗材借领：实现设备耗材查看、仪器外接申请、仪器归还、个人外借记录查看

8、实验设备管理数据库：管理员可以添加、删除、更改、查报废记录、修理记录、申请购买记录、新增设备及基本信息记录。

9、报废表、维修表、设备购买申请表、新增设备属性表最终在终端显示
## 实体ER属性：
用户: 学号,登录密码,所在班级,姓名,性别,出生日期,用户照片,联系电话,邮箱,家庭地址,注册时间

设备类别: 设备类别编号,设备类别名称

设备: 设备编号,设备名称,设备类型,设备图片,设备品牌,设备型号,生产厂家,出厂日期,设备价格,设备库存,设备描述

设备借用: 借用编号,借用的设备,借用数量,借用日期,借用天数,归还时间,借用人,备注信息

设备维修: 维修编号,损坏的设备,故障原因,故障数量,送修日期,送修地点,维修人,维修工时,维修费用,备注信息

报废设备: 报废id,报废的设备,报废原因,报废数量,折旧金额,报废日期,备注信息

设备事故: 事故id,事故的设备,事故原因,事故内容,事故时间,上报的用户

班级: 班级编号,班级名称,成立日期,班主任

新闻公告: 公告id,标题,公告内容,发布时间