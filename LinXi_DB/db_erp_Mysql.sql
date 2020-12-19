/*
 Navicat Premium Data Transfer

 Source Server         : mysql
 Source Server Type    : MySQL
 Source Server Version : 80020
 Source Host           : localhost:3306
 Source Schema         : db_erp

 Target Server Type    : MySQL
 Target Server Version : 80020
 File Encoding         : 65001

 Date: 19/12/2020 19:10:42
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for ac_department
-- ----------------------------
DROP TABLE IF EXISTS `ac_department`;
CREATE TABLE `ac_department`  (
  `id` int NOT NULL COMMENT '编号',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ac_department
-- ----------------------------
INSERT INTO `ac_department` VALUES (1, '销售部', '负责销售');
INSERT INTO `ac_department` VALUES (2, '采购部', '就打算v办法是v酒吧喝酒');
INSERT INTO `ac_department` VALUES (3, '生产部', '大大撒');
INSERT INTO `ac_department` VALUES (4, '质管部', NULL);
INSERT INTO `ac_department` VALUES (5, '仓管部', NULL);
INSERT INTO `ac_department` VALUES (6, '微机中心', NULL);
INSERT INTO `ac_department` VALUES (7, '美工部', '梅花');

-- ----------------------------
-- Table structure for ac_notice
-- ----------------------------
DROP TABLE IF EXISTS `ac_notice`;
CREATE TABLE `ac_notice`  (
  `id` int NOT NULL COMMENT '主键id',
  `createdate` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '创建时间',
  `title` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '公告标题',
  `detail` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '公告详情',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ac_notice
-- ----------------------------
INSERT INTO `ac_notice` VALUES (1, '2020/8/17 10:23:07', '国庆放假', '统一放假咯！');

-- ----------------------------
-- Table structure for ac_permission
-- ----------------------------
DROP TABLE IF EXISTS `ac_permission`;
CREATE TABLE `ac_permission`  (
  `id` int NOT NULL COMMENT '编号',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `url` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT 'URL',
  `pid` int NULL DEFAULT NULL COMMENT '上级权限',
  `is_menu` tinyint NULL DEFAULT NULL COMMENT '是否菜单',
  `icon` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '菜单图标',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ac_permission
-- ----------------------------
INSERT INTO `ac_permission` VALUES (8, '主页', '', 0, 1, 'fa-star', NULL);
INSERT INTO `ac_permission` VALUES (9, '基本信息', '', 0, 1, 'fa-folder', NULL);
INSERT INTO `ac_permission` VALUES (10, '客户信息', '/Customer/Index', 9, 1, NULL, NULL);
INSERT INTO `ac_permission` VALUES (11, '供应商信息', '/Suppliers/Index', 9, 1, NULL, NULL);
INSERT INTO `ac_permission` VALUES (12, '员工信息', '/StaffInfo/Index', 9, 1, NULL, NULL);
INSERT INTO `ac_permission` VALUES (13, '新增', '/StaffInfo/Add', 12, 0, NULL, NULL);
INSERT INTO `ac_permission` VALUES (14, '修改', '/StaffInfo/Edit', 12, 0, NULL, NULL);
INSERT INTO `ac_permission` VALUES (15, '删除', '/StaffInfo/Delete', 12, 0, NULL, NULL);
INSERT INTO `ac_permission` VALUES (16, '原料分类', '/GoodsCategory/Index', 9, 1, NULL, NULL);
INSERT INTO `ac_permission` VALUES (17, '销售管理', NULL, 0, 1, 'fa-shopping-cart', NULL);
INSERT INTO `ac_permission` VALUES (18, '生产管理', NULL, 0, 1, 'fa-product-hunt', NULL);
INSERT INTO `ac_permission` VALUES (19, '仓库管理', NULL, 0, 1, 'fa-archive', NULL);
INSERT INTO `ac_permission` VALUES (20, '采购管理', NULL, 0, 1, 'fa-shopping-basket', NULL);
INSERT INTO `ac_permission` VALUES (21, '质检管理', NULL, 0, 1, 'fa-magnet', NULL);
INSERT INTO `ac_permission` VALUES (22, '系统管理', NULL, 0, 1, 'fa-cog', NULL);
INSERT INTO `ac_permission` VALUES (23, '功能管理', '/Permissions/Index', 22, 1, NULL, NULL);
INSERT INTO `ac_permission` VALUES (24, '权限管理', '/Role/Index', 22, 1, NULL, NULL);
INSERT INTO `ac_permission` VALUES (25, '产品分类', '/ProductCategory/Index', 9, 1, NULL, NULL);

-- ----------------------------
-- Table structure for ac_role
-- ----------------------------
DROP TABLE IF EXISTS `ac_role`;
CREATE TABLE `ac_role`  (
  `id` int NOT NULL COMMENT '编号',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ac_role
-- ----------------------------
INSERT INTO `ac_role` VALUES (1, '系统管理员', NULL);
INSERT INTO `ac_role` VALUES (2, '客户档案员', NULL);
INSERT INTO `ac_role` VALUES (3, '订单员', NULL);
INSERT INTO `ac_role` VALUES (4, '退货员', NULL);
INSERT INTO `ac_role` VALUES (5, '销售主管', NULL);
INSERT INTO `ac_role` VALUES (6, '销售部长', NULL);
INSERT INTO `ac_role` VALUES (7, '供应商档案员', NULL);
INSERT INTO `ac_role` VALUES (8, '采购计划员', NULL);
INSERT INTO `ac_role` VALUES (9, '采购业务员', NULL);
INSERT INTO `ac_role` VALUES (10, '采购主管', NULL);
INSERT INTO `ac_role` VALUES (11, '采购部长', NULL);
INSERT INTO `ac_role` VALUES (12, '品质档案员', NULL);
INSERT INTO `ac_role` VALUES (13, '内检员', NULL);
INSERT INTO `ac_role` VALUES (14, '外检员', NULL);
INSERT INTO `ac_role` VALUES (15, '品质主管', NULL);
INSERT INTO `ac_role` VALUES (16, '品质部长', NULL);
INSERT INTO `ac_role` VALUES (17, '产品工艺员', NULL);
INSERT INTO `ac_role` VALUES (18, '开发部主管', NULL);
INSERT INTO `ac_role` VALUES (19, '开发部长', NULL);
INSERT INTO `ac_role` VALUES (20, '外协员', NULL);
INSERT INTO `ac_role` VALUES (21, '生产计划员', NULL);
INSERT INTO `ac_role` VALUES (22, '生产部长', NULL);
INSERT INTO `ac_role` VALUES (23, '领料员', NULL);
INSERT INTO `ac_role` VALUES (24, '生产入库员', NULL);
INSERT INTO `ac_role` VALUES (25, '调度员', NULL);
INSERT INTO `ac_role` VALUES (26, '车间主任', NULL);
INSERT INTO `ac_role` VALUES (27, '原材料创库员', NULL);
INSERT INTO `ac_role` VALUES (28, '半成品创库员', NULL);
INSERT INTO `ac_role` VALUES (29, '成品库管理员', NULL);
INSERT INTO `ac_role` VALUES (30, '辅料库管理员', NULL);
INSERT INTO `ac_role` VALUES (31, '仓库主管', NULL);

-- ----------------------------
-- Table structure for ac_role_permission
-- ----------------------------
DROP TABLE IF EXISTS `ac_role_permission`;
CREATE TABLE `ac_role_permission`  (
  `id` int NOT NULL COMMENT '编号',
  `role_id` int NOT NULL COMMENT '角色编号',
  `permission_id` int NOT NULL COMMENT '权限编号',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_ac_role_permission_ac_permission`(`permission_id`) USING BTREE,
  INDEX `FK_ac_role_permission_ac_role`(`role_id`) USING BTREE,
  CONSTRAINT `FK_ac_role_permission_ac_permission` FOREIGN KEY (`permission_id`) REFERENCES `ac_permission` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ac_role_permission_ac_role` FOREIGN KEY (`role_id`) REFERENCES `ac_role` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ac_role_permission
-- ----------------------------
INSERT INTO `ac_role_permission` VALUES (30, 1, 8);
INSERT INTO `ac_role_permission` VALUES (31, 1, 9);
INSERT INTO `ac_role_permission` VALUES (32, 1, 10);
INSERT INTO `ac_role_permission` VALUES (33, 1, 11);
INSERT INTO `ac_role_permission` VALUES (34, 1, 12);
INSERT INTO `ac_role_permission` VALUES (35, 1, 13);
INSERT INTO `ac_role_permission` VALUES (36, 1, 14);
INSERT INTO `ac_role_permission` VALUES (37, 1, 15);
INSERT INTO `ac_role_permission` VALUES (38, 1, 16);
INSERT INTO `ac_role_permission` VALUES (39, 1, 25);
INSERT INTO `ac_role_permission` VALUES (40, 1, 17);
INSERT INTO `ac_role_permission` VALUES (41, 1, 18);
INSERT INTO `ac_role_permission` VALUES (42, 1, 19);
INSERT INTO `ac_role_permission` VALUES (43, 1, 20);
INSERT INTO `ac_role_permission` VALUES (44, 1, 21);
INSERT INTO `ac_role_permission` VALUES (45, 1, 22);
INSERT INTO `ac_role_permission` VALUES (46, 1, 23);
INSERT INTO `ac_role_permission` VALUES (47, 1, 24);

-- ----------------------------
-- Table structure for ac_salary
-- ----------------------------
DROP TABLE IF EXISTS `ac_salary`;
CREATE TABLE `ac_salary`  (
  `id` int NOT NULL COMMENT '主键id，自增为1',
  `staff_id` int NOT NULL COMMENT '外键员工id',
  `createdate` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '创建日期',
  `base` int NOT NULL COMMENT '基本工资',
  `lunch` int NULL DEFAULT NULL COMMENT '午餐补贴',
  `live` int NULL DEFAULT NULL COMMENT '住房补贴',
  `hardwork` int NULL DEFAULT NULL COMMENT '全勤补贴',
  `extra` int NULL DEFAULT NULL COMMENT '额外补贴',
  `forfeit` int NULL DEFAULT NULL COMMENT '罚款金额',
  `tax` int NULL DEFAULT NULL COMMENT '税收金额',
  `sum` int NOT NULL COMMENT '总计金额',
  `grant` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '发放日期',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `staff_id`(`staff_id`) USING BTREE,
  CONSTRAINT `ac_salary_ibfk_1` FOREIGN KEY (`staff_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ac_salary
-- ----------------------------
INSERT INTO `ac_salary` VALUES (1, 4, '2020/8/15 ', 8100, 200, 200, 200, 200, 200, 200, 9300, '2020-08-11T16:00:00.000Z');
INSERT INTO `ac_salary` VALUES (2, 3, '2020/8/15 ', 8000, 100, 200, 200, 200, 200, 200, 9100, '2020-08-09T16:00:00.000Z');

-- ----------------------------
-- Table structure for ac_staff
-- ----------------------------
DROP TABLE IF EXISTS `ac_staff`;
CREATE TABLE `ac_staff`  (
  `id` int NOT NULL COMMENT '编号',
  `name` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '姓名',
  `sex` tinyint NOT NULL COMMENT '0：男，1：女',
  `no` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '员工编号',
  `tel` varchar(21) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '电话',
  `address` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '地址',
  `department_id` int NULL DEFAULT NULL COMMENT '部门',
  `status` tinyint NOT NULL COMMENT '0：离职，1：在职',
  `user_id` int NULL DEFAULT NULL COMMENT '账户id',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `IX_StaffInfo`(`no`) USING BTREE,
  INDEX `FK_ac_staff_ac_department`(`department_id`) USING BTREE,
  INDEX `FK_ac_staff_ac_userInfo`(`user_id`) USING BTREE,
  CONSTRAINT `FK_ac_staff_ac_department` FOREIGN KEY (`department_id`) REFERENCES `ac_department` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ac_staff_ac_userInfo` FOREIGN KEY (`user_id`) REFERENCES `ac_userinfo` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ac_staff
-- ----------------------------
INSERT INTO `ac_staff` VALUES (1, '李家', 1, '202001', '19908484483', '湖南工程', 1, 0, 1, NULL);
INSERT INTO `ac_staff` VALUES (3, '吴超', 1, '2002002', '11111111111', 'qawdasdas', 1, 1, NULL, NULL);
INSERT INTO `ac_staff` VALUES (4, '陈毅', 1, '12345', '12345342514', '湖南长沙', 4, 1, NULL, '无');
INSERT INTO `ac_staff` VALUES (5, '4', 1, '123435', '12345764536', '湖南长沙', 3, 1, NULL, '无');

-- ----------------------------
-- Table structure for ac_userinfo
-- ----------------------------
DROP TABLE IF EXISTS `ac_userinfo`;
CREATE TABLE `ac_userinfo`  (
  `id` int NOT NULL COMMENT '编号',
  `account` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '账号',
  `pwd` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '密码',
  `role_id` int NULL DEFAULT NULL COMMENT '角色编号',
  `staff_id` int NULL DEFAULT NULL COMMENT '员工编号',
  `status` int NULL DEFAULT NULL COMMENT '账户状态（1：正常0：冻结）',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_ac_userInfo_ac_role`(`role_id`) USING BTREE,
  INDEX `FK_ac_userInfo_ac_staff`(`staff_id`) USING BTREE,
  CONSTRAINT `FK_ac_userInfo_ac_role` FOREIGN KEY (`role_id`) REFERENCES `ac_role` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ac_userInfo_ac_staff` FOREIGN KEY (`staff_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ac_userinfo
-- ----------------------------
INSERT INTO `ac_userinfo` VALUES (1, 'admin', 'e5e567921a572dbbf747ba712857f8dd', 1, 1, 1);
INSERT INTO `ac_userinfo` VALUES (2, 'aaa', '123456', 2, 4, 0);

-- ----------------------------
-- Table structure for au_record
-- ----------------------------
DROP TABLE IF EXISTS `au_record`;
CREATE TABLE `au_record`  (
  `id` int NOT NULL COMMENT '编号',
  `source_type` int NULL DEFAULT NULL COMMENT '审批类型',
  `source_id` int NULL DEFAULT NULL COMMENT '审批单号',
  `operator_id` int NULL DEFAULT NULL COMMENT '操作人',
  `operate_time` datetime(0) NULL DEFAULT NULL COMMENT '操作时间',
  `operate_desc` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '操作意见',
  `approver_id` int NULL DEFAULT NULL COMMENT '处理人',
  `approve_time` datetime(0) NULL DEFAULT NULL COMMENT '处理时间',
  `approve_desc` datetime(0) NULL DEFAULT NULL COMMENT '处理备注',
  `approve_reult` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '处理结论',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `Relationship_32_FK`(`source_type`) USING BTREE,
  INDEX `FK_au_record_ac_staff`(`operator_id`) USING BTREE,
  INDEX `FK_au_record_ac_staff1`(`approver_id`) USING BTREE,
  CONSTRAINT `FK_au_record_ac_staff` FOREIGN KEY (`operator_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_au_record_ac_staff1` FOREIGN KEY (`approver_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of au_record
-- ----------------------------

-- ----------------------------
-- Table structure for ic_commodity_record
-- ----------------------------
DROP TABLE IF EXISTS `ic_commodity_record`;
CREATE TABLE `ic_commodity_record`  (
  `id` int NOT NULL COMMENT '编号',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '主题',
  `is_in` tinyint NULL DEFAULT NULL COMMENT '出入库',
  `source_category` int NULL DEFAULT NULL COMMENT '源单类型',
  `source_id` int NULL DEFAULT NULL COMMENT '源单ID',
  `source_no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '源单编号',
  `commodity_id` int NULL DEFAULT NULL COMMENT '商品',
  `batch` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '批次号',
  `nums` decimal(18, 2) NULL DEFAULT NULL COMMENT '数量',
  `reason` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '原因',
  `department_id` int NULL DEFAULT NULL COMMENT '出入库部门',
  `staff_id` int NULL DEFAULT NULL COMMENT '出入库员工',
  `warehouse_id` int NULL DEFAULT NULL COMMENT '仓库',
  `operator_id` int NULL DEFAULT NULL COMMENT '操作人',
  `operate_time` datetime(0) NULL DEFAULT NULL COMMENT '操作时间',
  `status` int NULL DEFAULT NULL COMMENT '状态',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `Relationship_19_FK`(`commodity_id`) USING BTREE,
  INDEX `FK_ic_commodity_record_ac_department`(`department_id`) USING BTREE,
  INDEX `FK_ic_commodity_record_ac_staff`(`staff_id`) USING BTREE,
  INDEX `FK_ic_commodity_record_ac_staff1`(`operator_id`) USING BTREE,
  INDEX `FK_ic_commodity_record_ic_warehouse`(`warehouse_id`) USING BTREE,
  CONSTRAINT `FK_ic_commodity_record_ac_department` FOREIGN KEY (`department_id`) REFERENCES `ac_department` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ic_commodity_record_ac_staff` FOREIGN KEY (`staff_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ic_commodity_record_ac_staff1` FOREIGN KEY (`operator_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ic_commodity_record_ic_warehouse` FOREIGN KEY (`warehouse_id`) REFERENCES `ic_warehouse` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ic_commodity_record_pu_commodity` FOREIGN KEY (`commodity_id`) REFERENCES `pu_commodity` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ic_commodity_record
-- ----------------------------
INSERT INTO `ic_commodity_record` VALUES (1, 'ss', 0, 0, 27, '1628022842', 1, '1', 12673.00, '操作员：李童辉==id：1于2020/8/15 17:00:24结款采购单，结款金额：全款	', 1, 1, NULL, 1, '2020-08-10 16:00:00', 1, 'gsgsgfh');
INSERT INTO `ic_commodity_record` VALUES (4, '出库', 1, 0, 1, '1', 2, '单件', 9.00, '放班上的', 3, 3, NULL, 1, '2020-08-11 16:00:00', 1, '');
INSERT INTO `ic_commodity_record` VALUES (6, '出库', 1, 0, 12324, '12324', 3, '单件', 1.00, '112', 5, 3, NULL, 1, '2020-08-21 16:00:00', 1, '');
INSERT INTO `ic_commodity_record` VALUES (7, '出库', 1, 0, 123, '123', 1, '单条', 111.00, 'Q', 3, 3, NULL, 1, '2020-08-14 16:00:00', 1, '');
INSERT INTO `ic_commodity_record` VALUES (10, 'ss', 0, 0, 29, '1628022844', 2, '1', 1.00, '操作员：李家==id：1于2020/8/15 23:09:30结款采购单，结款金额：全款	', 2, 1, NULL, 1, '2020-08-17 16:00:00', 1, 'qwe');
INSERT INTO `ic_commodity_record` VALUES (11, 'ss', 0, 0, 30, '1628022845', 1, '1', 11.00, '操作员：李家==id：1于2020/8/15 23:13:35结款采购单，结款金额：全款	', 2, 1, NULL, 1, '2020-08-17 16:00:00', 1, '');
INSERT INTO `ic_commodity_record` VALUES (12, '出库', 1, 0, 141325135, '141325135', 1, '单条', 12221.00, '1123', 2, 1, NULL, 1, '2020-08-18 16:00:00', 1, '');
INSERT INTO `ic_commodity_record` VALUES (13, '出库', 1, 0, 232, '232', 2, '单件', 65.00, '非常美官方', 3, 3, NULL, 1, '2020-08-15 16:00:00', 1, '');

-- ----------------------------
-- Table structure for ic_commodity_stock
-- ----------------------------
DROP TABLE IF EXISTS `ic_commodity_stock`;
CREATE TABLE `ic_commodity_stock`  (
  `id` int NOT NULL COMMENT '编号',
  `warehouse_id` int NULL DEFAULT NULL COMMENT '仓库',
  `commodity_id` int NULL DEFAULT NULL COMMENT '商品编号',
  `stock` decimal(18, 2) NULL DEFAULT NULL COMMENT '库存',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_ic_commodity_stock_ic_warehouse`(`warehouse_id`) USING BTREE,
  INDEX `FK_ic_commodity_stock_pu_commodity`(`commodity_id`) USING BTREE,
  CONSTRAINT `FK_ic_commodity_stock_ic_warehouse` FOREIGN KEY (`warehouse_id`) REFERENCES `ic_warehouse` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ic_commodity_stock_pu_commodity` FOREIGN KEY (`commodity_id`) REFERENCES `pu_commodity` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ic_commodity_stock
-- ----------------------------

-- ----------------------------
-- Table structure for ic_product_record
-- ----------------------------
DROP TABLE IF EXISTS `ic_product_record`;
CREATE TABLE `ic_product_record`  (
  `id` int NOT NULL COMMENT '编号',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '名称',
  `is_in` tinyint NULL DEFAULT NULL COMMENT '出入库',
  `source_category` int NULL DEFAULT NULL COMMENT '源单类型',
  `source_id` int NULL DEFAULT NULL COMMENT '源单编号',
  `source_no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '原单订单号',
  `product_id` int NULL DEFAULT NULL COMMENT '产品编号',
  `batch` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '批次号',
  `nums` decimal(18, 2) NULL DEFAULT NULL COMMENT '数量',
  `reason` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '原因',
  `department_id` int NULL DEFAULT NULL COMMENT '部门编号',
  `staff_id` int NULL DEFAULT NULL COMMENT '员工编号',
  `warehouse_id` int NULL DEFAULT NULL COMMENT '仓库编号',
  `operator_id` int NULL DEFAULT NULL COMMENT '操作人',
  `operate_time` datetime(0) NULL DEFAULT NULL COMMENT '操作时间',
  `status` int NULL DEFAULT NULL COMMENT '状态',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_ic_product_record_ac_department`(`department_id`) USING BTREE,
  INDEX `FK_ic_product_record_ac_staff`(`staff_id`) USING BTREE,
  INDEX `FK_ic_product_record_ac_staff1`(`operator_id`) USING BTREE,
  INDEX `FK_ic_product_record_ic_warehouse`(`warehouse_id`) USING BTREE,
  INDEX `FK_ic_product_record_pr_product`(`product_id`) USING BTREE,
  CONSTRAINT `FK_ic_product_record_ac_department` FOREIGN KEY (`department_id`) REFERENCES `ac_department` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ic_product_record_ac_staff` FOREIGN KEY (`staff_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ic_product_record_ac_staff1` FOREIGN KEY (`operator_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ic_product_record_ic_warehouse` FOREIGN KEY (`warehouse_id`) REFERENCES `ic_warehouse` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ic_product_record_pr_product` FOREIGN KEY (`product_id`) REFERENCES `pr_product` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ic_product_record
-- ----------------------------
INSERT INTO `ic_product_record` VALUES (11, '', NULL, 11, NULL, '', 1, 'rve', 9.00, '', 3, NULL, NULL, 1, '2020-08-15 15:52:58', 0, '');
INSERT INTO `ic_product_record` VALUES (12, '入库', 0, 0, 2, '2', 1, '22', 1.00, NULL, 1, 1, 1, 1, '2020-08-15 00:00:00', 1, NULL);
INSERT INTO `ic_product_record` VALUES (13, '', NULL, 3, NULL, '', 1, '1', 100.00, '', 1, NULL, NULL, 1, '2020-08-15 23:55:58', 0, '');
INSERT INTO `ic_product_record` VALUES (14, '出库', 1, 1, 33333, '33333', 1, '', 1.00, '', 1, 1, 1, 1, '2020-08-16 00:07:11', 2, NULL);
INSERT INTO `ic_product_record` VALUES (15, '出库', 1, 1, 33333, '33333', 1, '', 1.00, '', 1, 1, 1, 1, '2020-08-16 00:08:53', 2, NULL);
INSERT INTO `ic_product_record` VALUES (16, '入库', 0, 0, 14, '14', 2, '1', 11.00, NULL, 1, 1, 1, 1, '2020-08-16 00:00:00', 1, NULL);

-- ----------------------------
-- Table structure for ic_product_stock
-- ----------------------------
DROP TABLE IF EXISTS `ic_product_stock`;
CREATE TABLE `ic_product_stock`  (
  `id` int NOT NULL COMMENT '编号',
  `warehouse_id` int NULL DEFAULT NULL COMMENT '仓库号',
  `product_id` int NULL DEFAULT NULL COMMENT '产品编号',
  `stock` decimal(18, 2) NULL DEFAULT NULL COMMENT '库存数',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_ic_product_stock_ic_warehouse`(`warehouse_id`) USING BTREE,
  INDEX `FK_ic_product_stock_pr_product`(`product_id`) USING BTREE,
  CONSTRAINT `FK_ic_product_stock_ic_warehouse` FOREIGN KEY (`warehouse_id`) REFERENCES `ic_warehouse` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ic_product_stock_pr_product` FOREIGN KEY (`product_id`) REFERENCES `pr_product` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ic_product_stock
-- ----------------------------

-- ----------------------------
-- Table structure for ic_warehouse
-- ----------------------------
DROP TABLE IF EXISTS `ic_warehouse`;
CREATE TABLE `ic_warehouse`  (
  `id` int NOT NULL COMMENT '编号',
  `no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '仓库编号',
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `category` int NULL DEFAULT NULL COMMENT '仓库类型',
  `address` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '地址',
  `manager_id` int NULL DEFAULT NULL COMMENT '管理员',
  `operator_id` int NULL DEFAULT NULL COMMENT '操作人',
  `operate_time` datetime(0) NULL DEFAULT NULL COMMENT '操作时间',
  `status` int NULL DEFAULT NULL COMMENT '状态',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ic_warehouse
-- ----------------------------
INSERT INTO `ic_warehouse` VALUES (1, '232', '仓库一', NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for pr_product
-- ----------------------------
DROP TABLE IF EXISTS `pr_product`;
CREATE TABLE `pr_product`  (
  `id` int NOT NULL COMMENT '编号',
  `category_id` int NULL DEFAULT NULL COMMENT '产品分类',
  `bar_code` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '条码',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '名称',
  `price` decimal(19, 4) NULL DEFAULT NULL COMMENT '价格',
  `stock` decimal(18, 2) NULL DEFAULT NULL COMMENT '库存',
  `license_no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '批文',
  `spec` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '规格',
  `unit` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '单位',
  `place` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '产地',
  `manufacturer` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '生产厂家',
  `operator_id` int NULL DEFAULT NULL COMMENT '操作人',
  `operator_time` datetime(0) NULL DEFAULT NULL COMMENT '操作时间',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `Relationship_26_FK`(`category_id`) USING BTREE,
  CONSTRAINT `FK_pr_product_pr_product_category` FOREIGN KEY (`category_id`) REFERENCES `pr_product_category` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of pr_product
-- ----------------------------
INSERT INTO `pr_product` VALUES (1, 3, '575746574848', '联想小新Air15', 5400.0000, 1225.00, '24234323', '台', '台', '中国台湾', '本公司', 1, '2020-08-11 16:16:43', NULL);
INSERT INTO `pr_product` VALUES (2, 4, '4234234', 'Test', 423.0000, 11.00, 'faff', '拔丝地瓜', '台', '长沙', '本公司', 1, '2020-08-15 16:10:04', '');

-- ----------------------------
-- Table structure for pr_product_category
-- ----------------------------
DROP TABLE IF EXISTS `pr_product_category`;
CREATE TABLE `pr_product_category`  (
  `id` int NOT NULL COMMENT '编号',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '名称',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of pr_product_category
-- ----------------------------
INSERT INTO `pr_product_category` VALUES (1, 'ShuraX', NULL);
INSERT INTO `pr_product_category` VALUES (2, 'ShuraA', NULL);
INSERT INTO `pr_product_category` VALUES (3, '笔记本', NULL);
INSERT INTO `pr_product_category` VALUES (4, '手机', NULL);
INSERT INTO `pr_product_category` VALUES (5, '交换机', NULL);

-- ----------------------------
-- Table structure for pr_product_material
-- ----------------------------
DROP TABLE IF EXISTS `pr_product_material`;
CREATE TABLE `pr_product_material`  (
  `id` int NOT NULL COMMENT '编号',
  `task_id` int NULL DEFAULT NULL COMMENT '生产任务',
  `commodity_id` int NULL DEFAULT NULL COMMENT '物料编号',
  `nums` int NULL DEFAULT NULL COMMENT '数量',
  `uses` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '用途',
  `department_id` int NULL DEFAULT NULL COMMENT '领用部门',
  `staff_id` int NULL DEFAULT NULL COMMENT '领用人',
  `receipt_date` decimal(18, 0) NULL DEFAULT NULL COMMENT '领用日期',
  `operator_id` int NULL DEFAULT NULL COMMENT '操作人',
  `operate_time` datetime(0) NULL DEFAULT NULL COMMENT '操作时间',
  `status` int NULL DEFAULT NULL COMMENT '状态',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `Relationship_29_FK`(`task_id`) USING BTREE,
  INDEX `FK_pr_product_material_ac_department`(`department_id`) USING BTREE,
  INDEX `FK_pr_product_material_ac_staff`(`staff_id`) USING BTREE,
  INDEX `FK_pr_product_material_ac_staff1`(`operator_id`) USING BTREE,
  INDEX `FK_pr_product_material_pr_product_task`(`status`) USING BTREE,
  INDEX `FK_pr_product_material_pu_commodity`(`commodity_id`) USING BTREE,
  CONSTRAINT `FK_pr_product_material_ac_department` FOREIGN KEY (`department_id`) REFERENCES `ac_department` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_pr_product_material_ac_staff` FOREIGN KEY (`staff_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_pr_product_material_ac_staff1` FOREIGN KEY (`operator_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_pr_product_material_pr_product_task` FOREIGN KEY (`task_id`) REFERENCES `pr_product_task` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_pr_product_material_pu_commodity` FOREIGN KEY (`commodity_id`) REFERENCES `pu_commodity` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of pr_product_material
-- ----------------------------
INSERT INTO `pr_product_material` VALUES (1, 11, 2, 9, '放班上的', 3, 3, NULL, 1, '2020-08-15 15:45:14', 2, '');
INSERT INTO `pr_product_material` VALUES (5, 3, 1, 100, '淦', 1, 4, NULL, 1, '2020-08-15 23:55:13', 0, '');
INSERT INTO `pr_product_material` VALUES (123, 1, 1, 111, 'Q', 3, 3, NULL, 1, '2020-08-15 17:24:55', 2, 'QW');
INSERT INTO `pr_product_material` VALUES (232, 13, 2, 65, '非常美官方', 3, 3, NULL, 1, '2020-08-16 13:09:17', 2, '');
INSERT INTO `pr_product_material` VALUES (1232, 2, 1, 123, '123', 3, 1, NULL, 1, '2020-08-15 17:53:10', 2, '1232');
INSERT INTO `pr_product_material` VALUES (1234, 11, 1, 123, '12', 4, 1, NULL, 1, '2020-08-15 18:11:49', 2, '123');
INSERT INTO `pr_product_material` VALUES (12324, 11, 3, 1, '112', 5, 3, NULL, 1, '2020-08-15 22:45:38', 2, '123');
INSERT INTO `pr_product_material` VALUES (141325135, 11, 1, 12221, '1123', 2, 1, NULL, 1, '2020-08-15 23:14:20', 2, '3412');

-- ----------------------------
-- Table structure for pr_product_task
-- ----------------------------
DROP TABLE IF EXISTS `pr_product_task`;
CREATE TABLE `pr_product_task`  (
  `id` int NOT NULL COMMENT '编号',
  `no` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '生产单号',
  `product_id` int NULL DEFAULT NULL COMMENT '产品编号',
  `nums` decimal(18, 2) NULL DEFAULT NULL COMMENT '数量',
  `product_date` date NULL DEFAULT NULL COMMENT '生产日期',
  `batch` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '批次号',
  `department_id` int NULL DEFAULT NULL COMMENT '部门编号',
  `operator_id` int NULL DEFAULT NULL COMMENT '操作人',
  `operate_time` datetime(0) NULL DEFAULT NULL COMMENT '操作时间',
  `status` int NULL DEFAULT NULL COMMENT '状态',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  `qm_id` int NULL DEFAULT NULL COMMENT '质检编号',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_pr_product_task_ac_staff`(`operator_id`) USING BTREE,
  INDEX `FK_pr_product_task_pr_product`(`product_id`) USING BTREE,
  INDEX `FK_pr_product_task_qm_product`(`qm_id`) USING BTREE,
  INDEX `FK_pr_product_task_ac_department`(`department_id`) USING BTREE,
  CONSTRAINT `FK_pr_product_task_ac_department` FOREIGN KEY (`department_id`) REFERENCES `ac_department` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_pr_product_task_ac_staff` FOREIGN KEY (`operator_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_pr_product_task_pr_product` FOREIGN KEY (`product_id`) REFERENCES `pr_product` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_pr_product_task_qm_product` FOREIGN KEY (`qm_id`) REFERENCES `qm_product` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of pr_product_task
-- ----------------------------
INSERT INTO `pr_product_task` VALUES (1, '1', 1, 1.00, '2020-08-15', '11', 1, 1, '2020-08-15 14:25:08', 2, NULL, 1);
INSERT INTO `pr_product_task` VALUES (2, '2', 1, 1.00, '2020-08-15', '22', 1, 1, '2020-08-15 00:00:00', 3, NULL, 2);
INSERT INTO `pr_product_task` VALUES (3, '5', 1, 100.00, '2020-07-18', '1', 1, 1, '2020-08-15 23:54:03', 1, '', NULL);
INSERT INTO `pr_product_task` VALUES (11, '3', 1, 9.00, '2020-06-19', '发过火', 3, 1, '2020-08-15 15:33:41', 4, '', NULL);
INSERT INTO `pr_product_task` VALUES (13, '43', 1, 44.00, '2020-07-19', '有分寸', 3, 1, '2020-08-16 13:06:27', 4, '', NULL);
INSERT INTO `pr_product_task` VALUES (14, '14', 2, 11.00, '2020-08-16', '1', 1, 1, '2020-08-16 00:00:00', 3, NULL, 14);

-- ----------------------------
-- Table structure for pu_commodity
-- ----------------------------
DROP TABLE IF EXISTS `pu_commodity`;
CREATE TABLE `pu_commodity`  (
  `id` int NOT NULL COMMENT '编号',
  `category_id` int NULL DEFAULT NULL COMMENT '分类编号',
  `supplier_id` int NULL DEFAULT NULL COMMENT '供应商编号',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '名称',
  `price` decimal(19, 4) NULL DEFAULT NULL COMMENT '价格',
  `stock` decimal(18, 2) NULL DEFAULT NULL COMMENT '库存',
  `place` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '产地',
  `spec` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '规格',
  `license_no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '生产批文',
  `operator_id` int NULL DEFAULT NULL COMMENT '操作人',
  `operate_time` datetime(0) NULL DEFAULT NULL COMMENT '操作时间',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `Relationship_10_FK`(`category_id`) USING BTREE,
  INDEX `Relationship_20_FK`(`supplier_id`) USING BTREE,
  INDEX `FK_pu_commodity_ac_staff`(`operator_id`) USING BTREE,
  CONSTRAINT `FK_pu_commodity_ac_staff` FOREIGN KEY (`operator_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_pu_commodity_pu_commodity_category` FOREIGN KEY (`category_id`) REFERENCES `pu_commodity_category` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_pu_commodity_pu_supplier` FOREIGN KEY (`supplier_id`) REFERENCES `pu_supplier` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of pu_commodity
-- ----------------------------
INSERT INTO `pu_commodity` VALUES (1, 3, 1, '三星内存条8G', 400.0000, 862.00, '中国', '单条', 'LX-78995', 1, '2020-08-08 11:27:46', NULL);
INSERT INTO `pu_commodity` VALUES (2, 1, 1, '英特尔i9-9980XE', 4000.0000, 27.00, '中国', '单件', 'LX-78996', 1, '2020-08-10 11:27:46', NULL);
INSERT INTO `pu_commodity` VALUES (3, 2, 1, 'AMD锐龙R5-3600', 1000.0000, 285.00, '中国', '单件', 'LX-78997', 1, '2020-08-13 11:27:46', NULL);

-- ----------------------------
-- Table structure for pu_commodity_category
-- ----------------------------
DROP TABLE IF EXISTS `pu_commodity_category`;
CREATE TABLE `pu_commodity_category`  (
  `id` int NOT NULL COMMENT '编号',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '名称',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of pu_commodity_category
-- ----------------------------
INSERT INTO `pu_commodity_category` VALUES (1, 'CPU', NULL);
INSERT INTO `pu_commodity_category` VALUES (2, '显卡', NULL);
INSERT INTO `pu_commodity_category` VALUES (3, '内存条', NULL);

-- ----------------------------
-- Table structure for pu_order
-- ----------------------------
DROP TABLE IF EXISTS `pu_order`;
CREATE TABLE `pu_order`  (
  `id` int NOT NULL COMMENT '编号',
  `no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '订单号',
  `commodity_id` int NULL DEFAULT NULL COMMENT '商品编号',
  `nums` decimal(18, 2) NULL DEFAULT NULL COMMENT '数量',
  `purchase_date` date NULL DEFAULT NULL COMMENT '采购时间',
  `batch` char(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '批次号',
  `amount` decimal(19, 4) NULL DEFAULT NULL COMMENT '金额',
  `amount_way` int NULL DEFAULT NULL COMMENT '结算方式',
  `amount_receivable` decimal(19, 4) NULL DEFAULT NULL COMMENT '应收金额',
  `amount_received` decimal(19, 4) NULL DEFAULT NULL COMMENT '实收金额',
  `handle_id` int NULL DEFAULT NULL COMMENT '经手人',
  `operator_id` int NULL DEFAULT NULL COMMENT '操作人',
  `operate_time` datetime(0) NULL DEFAULT NULL COMMENT '操作时间',
  `status` int NULL DEFAULT NULL COMMENT '状态',
  `qm_id` int NULL DEFAULT NULL COMMENT '质检单编号',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_pu_order_ac_staff`(`handle_id`) USING BTREE,
  INDEX `FK_pu_order_pu_commodity`(`commodity_id`) USING BTREE,
  INDEX `FK_pu_order_qm_commodity`(`qm_id`) USING BTREE,
  CONSTRAINT `FK_pu_order_ac_staff` FOREIGN KEY (`handle_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_pu_order_pu_commodity` FOREIGN KEY (`commodity_id`) REFERENCES `pu_commodity` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_pu_order_qm_commodity` FOREIGN KEY (`qm_id`) REFERENCES `qm_commodity` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of pu_order
-- ----------------------------
INSERT INTO `pu_order` VALUES (1, '1628022817', 1, 100.00, '2020-08-08', '1', 40000.0000, 1, 40000.0000, 20000.0000, 1, 1, '2020-08-10 11:36:44', 2, NULL, '操作员：李童辉==id：1于2020/8/10 11:36:44结款采购单，结款金额：全款	');
INSERT INTO `pu_order` VALUES (2, '1628022818', 1, 201.00, '2020-07-01', '1', 80000.0000, 1, 80000.0000, 1000.0000, 1, 1, '2020-08-09 19:20:48', 0, NULL, '操作员：李童辉==id：1于2020/8/10 11:36:56修改采购单	');
INSERT INTO `pu_order` VALUES (3, '1628022819', 1, 200.00, '2020-06-17', '1', 120000.0000, 2, 80000.0000, 0.0000, 1, 1, '2020-08-09 19:34:53', 1, NULL, '操作员：李童辉==id：1于2020/8/10 11:37:01进行退货	');
INSERT INTO `pu_order` VALUES (4, '1628022820', 1, 200.00, '2020-05-22', '1', 80000.0000, 2, 80000.0000, 80000.0000, 1, 1, '2020-08-09 19:34:53', 3, NULL, NULL);
INSERT INTO `pu_order` VALUES (5, '1628022821', 1, 200.00, '2020-08-09', '1', 120000.0000, 2, 80000.0000, 0.0000, 1, 1, '2020-08-09 19:34:53', 5, NULL, NULL);
INSERT INTO `pu_order` VALUES (6, '1628022822', 1, 200.00, '2020-07-10', '1', 120000.0000, 2, 80000.0000, 0.0000, 1, 1, '2020-08-09 19:34:53', 5, NULL, NULL);
INSERT INTO `pu_order` VALUES (7, '1628022822', 1, 200.00, '2020-06-19', '1', 120000.0000, 2, 80000.0000, 0.0000, 1, 1, '2020-08-09 19:34:53', 6, NULL, NULL);
INSERT INTO `pu_order` VALUES (8, '1628022823', 2, 200.00, '2020-06-19', '1', 120000.0000, 2, 80000.0000, 0.0000, 1, 1, '2020-08-10 19:34:53', 0, NULL, NULL);
INSERT INTO `pu_order` VALUES (9, '1628022824', 2, 199.00, '2020-06-19', '1', 120000.0000, 2, 80000.0000, 0.0000, 1, 1, '2020-08-10 19:34:53', 0, NULL, '操作员：李童辉==id：1于2020/8/13 15:54:08修改采购单	');
INSERT INTO `pu_order` VALUES (10, '1628022825', 2, 200.00, '2020-06-19', '1', 120000.0000, 2, 80000.0000, 0.0000, 1, 1, '2020-08-10 19:34:53', 0, NULL, NULL);
INSERT INTO `pu_order` VALUES (11, '1628022826', 3, 200.00, '2020-06-19', '1', 120000.0000, 2, 80000.0000, 0.0000, 1, 1, '2020-08-10 19:34:53', 0, NULL, NULL);
INSERT INTO `pu_order` VALUES (12, '1628022827', 3, 200.00, '2020-06-19', '1', 120000.0000, 2, 80000.0000, 0.0000, 1, 1, '2020-08-10 19:34:53', 0, NULL, NULL);
INSERT INTO `pu_order` VALUES (13, '1628022828', 3, 200.00, '2020-06-19', '1', 120000.0000, 2, 80000.0000, 0.0000, 1, 1, '2020-08-10 19:34:53', 0, NULL, NULL);
INSERT INTO `pu_order` VALUES (14, '1628022829', 1, 200.00, '2020-06-19', '1', 120000.0000, 2, 80000.0000, 0.0000, 1, 1, '2020-08-10 19:34:53', 0, NULL, NULL);
INSERT INTO `pu_order` VALUES (15, '1628022830', 2, 200.00, '2020-06-19', '1', 120000.0000, 2, 80000.0000, 0.0000, 1, 1, '2020-08-10 19:34:53', 0, NULL, NULL);
INSERT INTO `pu_order` VALUES (16, '1628022831', 3, 200.00, '2020-06-19', '1', 80000.0000, 2, 80000.0000, 80000.0000, 1, 1, '2020-08-10 19:34:53', 3, NULL, NULL);
INSERT INTO `pu_order` VALUES (17, '1628022832', 2, 200.00, '2020-06-19', '1', 120000.0000, 2, 80000.0000, 0.0000, 1, 1, '2020-08-10 19:34:53', 0, NULL, NULL);
INSERT INTO `pu_order` VALUES (18, '1628022833', 2, 1.00, '2020-08-10', '1', 4000.0000, 1, 4000.0000, 0.0000, 1, 1, '2020-08-10 23:07:55', 0, NULL, NULL);
INSERT INTO `pu_order` VALUES (19, '1628022834', 1, 1.00, '2020-08-10', '1', 400.0000, 1, 400.0000, 0.0000, 1, 1, '2020-08-10 23:09:39', 0, NULL, NULL);
INSERT INTO `pu_order` VALUES (20, '1628022835', 1, 1.00, '2020-08-10', '1', 400.0000, 1, 400.0000, 0.0000, 1, 1, '2020-08-10 23:11:11', 0, NULL, NULL);
INSERT INTO `pu_order` VALUES (21, '1628022836', 3, 1.00, '2020-08-10', '1', 1000.0000, 1, 1000.0000, 0.0000, 1, 1, '2020-08-10 23:12:04', 0, NULL, NULL);
INSERT INTO `pu_order` VALUES (22, '1628022837', 3, 1.00, '2020-08-10', '1', 1000.0000, 1, 1000.0000, 0.0000, 1, 1, '2020-08-10 23:12:29', 0, NULL, NULL);
INSERT INTO `pu_order` VALUES (23, '1628022838', 1, 1.00, '2020-08-10', '1', 400.0000, 1, 400.0000, 0.0000, 1, 1, '2020-08-10 23:12:41', 2, 1628022838, NULL);
INSERT INTO `pu_order` VALUES (24, '1628022839', 2, 156.00, '2020-08-11', '1', 4000.0000, 1, 4000.0000, 0.0000, 1, 1, '2020-08-11 08:45:03', 2, 1628022839, '操作员：李童辉==id：1于2020/8/11 8:45:20修改采购单	');
INSERT INTO `pu_order` VALUES (25, '1628022840', 3, 1.00, '2020-08-11', '1', 1000.0000, 1, 1000.0000, 0.0000, 1, 1, '2020-08-11 08:53:25', 2, 1628022840, NULL);
INSERT INTO `pu_order` VALUES (26, '1628022841', 3, 187.00, '2020-08-11', '1', 187000.0000, 2, 187000.0000, 0.0000, 1, 1, '2020-08-11 09:27:22', 5, 1628022841, NULL);
INSERT INTO `pu_order` VALUES (27, '1628022842', 1, 12673.00, '2020-08-15', '1', 5069200.0000, 1, 5069200.0000, 5069200.0000, 1, 1, '2020-08-15 17:00:24', 5, 1628022842, '操作员：李童辉==id：1于2020/8/15 17:00:24结款采购单，结款金额：全款	');
INSERT INTO `pu_order` VALUES (28, '1628022843', 1, 1.00, '2020-08-15', '1', 400.0000, 1, 400.0000, 400.0000, 1, 1, '2020-08-15 23:06:20', 5, 1628022843, '操作员：李家==id：1于2020/8/15 23:06:19结款采购单，结款金额：全款	');
INSERT INTO `pu_order` VALUES (29, '1628022844', 2, 1.00, '2020-08-15', '1', 4000.0000, 1, 4000.0000, 4000.0000, 1, 1, '2020-08-15 23:09:30', 5, 1628022844, '操作员：李家==id：1于2020/8/15 23:09:30结款采购单，结款金额：全款	');
INSERT INTO `pu_order` VALUES (30, '1628022845', 1, 11.00, '2020-08-15', '1', 4400.0000, 1, 4400.0000, 4400.0000, 1, 1, '2020-08-15 23:13:36', 5, 1628022845, '操作员：李家==id：1于2020/8/15 23:13:35结款采购单，结款金额：全款	');
INSERT INTO `pu_order` VALUES (31, '1628022846', 1, 7.00, '2020-09-03', '1', 2800.0000, 1, 2800.0000, 0.0000, 1, 1, '2020-09-03 17:44:07', 0, NULL, NULL);
INSERT INTO `pu_order` VALUES (32, '1628022847', 1, 1.00, '2020-09-03', '1', 400.0000, 2, 400.0000, 0.0000, 1, 1, '2020-09-03 17:44:16', 0, NULL, NULL);
INSERT INTO `pu_order` VALUES (33, '1628022848', 3, 1.00, '2020-09-03', '1', 1000.0000, 1, 1000.0000, 0.0000, 1, 1, '2020-09-03 17:44:27', 0, NULL, NULL);

-- ----------------------------
-- Table structure for pu_supplier
-- ----------------------------
DROP TABLE IF EXISTS `pu_supplier`;
CREATE TABLE `pu_supplier`  (
  `id` int NOT NULL COMMENT '编号',
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '名称',
  `postcode` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '邮编',
  `address` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '地址',
  `linkman` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '联系人',
  `tel` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '电话',
  `qq` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT 'QQ',
  `weixin` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '微信',
  `email` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '邮箱',
  `credit` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '信誉度',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  `operator_id` int NULL DEFAULT NULL,
  `operate_time` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_pu_supplier_ac_staff`(`operator_id`) USING BTREE,
  CONSTRAINT `FK_pu_supplier_ac_staff` FOREIGN KEY (`operator_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of pu_supplier
-- ----------------------------
INSERT INTO `pu_supplier` VALUES (1, '智星', '410645', '湖北仙桃', 'Mr.Chen', '17673457151', '1812613402', 'Chen', 'chenyigg123@163.com', '5', NULL, 1, '2020-08-08 10:29:55');

-- ----------------------------
-- Table structure for qm_commodity
-- ----------------------------
DROP TABLE IF EXISTS `qm_commodity`;
CREATE TABLE `qm_commodity`  (
  `id` int NOT NULL COMMENT '编号',
  `no` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '质检单号',
  `order_id` int NULL DEFAULT NULL COMMENT '采购单编号',
  `qm_date` date NULL DEFAULT NULL COMMENT '质检日期',
  `result` int NULL DEFAULT NULL COMMENT '结论',
  `handle_id` int NULL DEFAULT NULL COMMENT '经手人',
  `operator_id` int NULL DEFAULT NULL COMMENT '操作人',
  `operate_time` datetime(0) NULL DEFAULT NULL COMMENT '操作时间',
  `pic` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '图片',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_qm_commodity_ac_staff`(`handle_id`) USING BTREE,
  INDEX `FK_qm_commodity_ac_staff1`(`operator_id`) USING BTREE,
  INDEX `FK_qm_commodity_pu_order`(`order_id`) USING BTREE,
  CONSTRAINT `FK_qm_commodity_ac_staff` FOREIGN KEY (`handle_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_qm_commodity_ac_staff1` FOREIGN KEY (`operator_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_qm_commodity_pu_order` FOREIGN KEY (`order_id`) REFERENCES `pu_order` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of qm_commodity
-- ----------------------------
INSERT INTO `qm_commodity` VALUES (1628022838, '1628022838', 23, '2020-08-10', 1, 1, 1, '2020-08-15 23:03:58', '', '欧克');
INSERT INTO `qm_commodity` VALUES (1628022839, '1628022839', 24, '2020-08-14', 1, 1, 1, '2020-08-15 14:41:13', '', '');
INSERT INTO `qm_commodity` VALUES (1628022840, '1628022840', 25, '2020-08-14', 1, 1, 1, '2020-08-15 14:30:48', '', '');
INSERT INTO `qm_commodity` VALUES (1628022841, '1628022841', 26, '2020-08-14', 1, 1, 1, '2020-08-15 14:19:21', '', '');
INSERT INTO `qm_commodity` VALUES (1628022842, '1628022842', 27, '2020-08-14', 1, 1, 1, '2020-08-15 16:59:40', '', '');
INSERT INTO `qm_commodity` VALUES (1628022843, '1628022843', 28, '2020-08-19', 1, 1, 1, '2020-08-15 23:06:01', '', '123');
INSERT INTO `qm_commodity` VALUES (1628022844, '1628022844', 29, '2020-08-11', 1, 1, 1, '2020-08-15 23:09:19', '', 'qwqw');
INSERT INTO `qm_commodity` VALUES (1628022845, '1628022845', 30, '2020-08-12', 1, 1, 1, '2020-08-15 23:13:11', '', 'qqq');

-- ----------------------------
-- Table structure for qm_product
-- ----------------------------
DROP TABLE IF EXISTS `qm_product`;
CREATE TABLE `qm_product`  (
  `id` int NOT NULL COMMENT '编号',
  `no` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '质检单号',
  `task_id` int NULL DEFAULT NULL COMMENT '生产单编号',
  `qm_date` date NULL DEFAULT NULL COMMENT '质检日期',
  `result` int NULL DEFAULT NULL COMMENT '质检结论',
  `handle_id` int NULL DEFAULT NULL COMMENT '经手人',
  `operator_id` int NULL DEFAULT NULL COMMENT '操作人',
  `operate_time` datetime(0) NULL DEFAULT NULL COMMENT '操作时间',
  `pic` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '质检图片',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_qm_product_ac_staff`(`handle_id`) USING BTREE,
  INDEX `FK_qm_product_ac_staff1`(`operator_id`) USING BTREE,
  INDEX `FK_qm_product_pr_product_task`(`task_id`) USING BTREE,
  CONSTRAINT `FK_qm_product_ac_staff` FOREIGN KEY (`handle_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_qm_product_ac_staff1` FOREIGN KEY (`operator_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_qm_product_pr_product_task` FOREIGN KEY (`task_id`) REFERENCES `pr_product_task` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of qm_product
-- ----------------------------
INSERT INTO `qm_product` VALUES (1, '1', 1, '2020-08-14', 1, 1, 1, '2020-08-15 14:25:57', '', '');
INSERT INTO `qm_product` VALUES (2, '2', 2, '2020-08-14', 2, 1, 1, '2020-08-15 14:31:22', '', '');
INSERT INTO `qm_product` VALUES (14, '14', 14, '2020-08-15', 1, 1, 1, '2020-08-16 13:45:48', '', '');

-- ----------------------------
-- Table structure for sl_customer
-- ----------------------------
DROP TABLE IF EXISTS `sl_customer`;
CREATE TABLE `sl_customer`  (
  `id` int NOT NULL COMMENT '编号',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '姓名',
  `postcode` char(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '邮编',
  `address` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '地址',
  `custtel` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '客户电话',
  `linkman` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '联系人',
  `linktel` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '联系方式',
  `email` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '邮箱',
  `sex` tinyint NULL DEFAULT NULL COMMENT '性别',
  `birthday` date NULL DEFAULT NULL COMMENT '生日',
  `love` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '爱好',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sl_customer
-- ----------------------------
INSERT INTO `sl_customer` VALUES (1, '蓝天网咖72', '44368', '湖北', '17673457151', '曜', '17673457151', 'chenyigg123@163.com', 0, '2020-08-11', '打球', NULL);
INSERT INTO `sl_customer` VALUES (2, ' 啊手动', '123456', 'asdfsadf', '18229534024', 'sdaf', '18229534024', '416800', 1, '2020-08-11', 'sdvx', 'sdfsad');
INSERT INTO `sl_customer` VALUES (3, 'etsa', '123123', 'asdfasdf', '12345678901', 'sdafsdfa', '12345678901', '133333', 1, '2020-08-20', 'sadf', 'sdfsdfa');
INSERT INTO `sl_customer` VALUES (4, '李白', '42343', '湖北', '17262735261', '李先生', '17262735261', '31441234', 1, '2020-08-17', '爱海', NULL);

-- ----------------------------
-- Table structure for sl_order
-- ----------------------------
DROP TABLE IF EXISTS `sl_order`;
CREATE TABLE `sl_order`  (
  `id` int NOT NULL COMMENT '编号',
  `no` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '订单编号',
  `customer_id` int NOT NULL COMMENT '客户编号',
  `product_id` int NOT NULL COMMENT '产品编号',
  `nums` decimal(10, 2) NOT NULL COMMENT '数量',
  `price` decimal(10, 2) NULL DEFAULT NULL COMMENT '单价',
  `delivery_date` date NULL DEFAULT NULL COMMENT '交货日期',
  `delivery_way` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '交货方式',
  `order_date` date NULL DEFAULT NULL COMMENT '下单时间',
  `order_amount` decimal(18, 2) NULL DEFAULT NULL COMMENT '订单金额',
  `handle_id` int NULL DEFAULT NULL COMMENT '经手人',
  `operator_id` int NULL DEFAULT NULL COMMENT '操作员',
  `operator_time` datetime(0) NULL DEFAULT NULL COMMENT '操作时间',
  `status` int NULL DEFAULT NULL COMMENT '状态(0待审核，1已审核，2待发货，3已出库，-1审核不通过)',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `Relationship_23_FK`(`customer_id`) USING BTREE,
  INDEX `FK_sl_order_ac_staff`(`handle_id`) USING BTREE,
  INDEX `FK_sl_order_ac_staff1`(`operator_id`) USING BTREE,
  INDEX `FK_sl_order_pr_product`(`product_id`) USING BTREE,
  CONSTRAINT `FK_sl_order_ac_staff` FOREIGN KEY (`handle_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_sl_order_ac_staff1` FOREIGN KEY (`operator_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_sl_order_pr_product` FOREIGN KEY (`product_id`) REFERENCES `pr_product` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_sl_order_sl_customer` FOREIGN KEY (`customer_id`) REFERENCES `sl_customer` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sl_order
-- ----------------------------
INSERT INTO `sl_order` VALUES (1, '1', 1, 1, 100.00, 400.00, '2020-08-11', '顺丰', '2020-08-09', 40000.00, 1, 1, '2020-08-09 16:21:27', 3, NULL);
INSERT INTO `sl_order` VALUES (17, '17', 4, 1, 1000.00, 5400.00, '2020-08-16', '1111', '2020-08-16', 5400000.00, 1, 1, '2020-08-16 14:41:13', 1, NULL);
INSERT INTO `sl_order` VALUES (34, '34', 1, 1, 1.00, 5400.00, '2020-08-25', '面交', '2020-08-15', 5400.00, 1, 1, '2020-08-15 14:37:42', 0, '');
INSERT INTO `sl_order` VALUES (43, '43', 1, 1, 666.00, 5400.00, '2020-08-12', '圆通', '2020-08-15', 3596400.00, 1, 1, '2020-08-15 23:58:46', 1, '');
INSERT INTO `sl_order` VALUES (44, '44', 4, 2, 1.00, 423.00, '2020-08-15', '顺丰', '2020-08-16', 423.00, 1, 1, '2020-08-16 14:39:40', 1, '');
INSERT INTO `sl_order` VALUES (45, '45', 1, 1, 45.00, 5400.00, '2020-08-15', '顺丰', '2020-08-16', 243000.00, 1, 1, '2020-08-16 15:00:07', 3, NULL);
INSERT INTO `sl_order` VALUES (46, '46', 3, 2, 1.00, 423.00, '2020-08-17', '顺丰', '2020-08-16', 423.00, 1, 1, '2020-08-16 15:09:03', 0, '');
INSERT INTO `sl_order` VALUES (47, '47', 2, 2, 1.00, 423.00, '2020-08-09', '圆通', '2020-08-16', 423.00, 1, 1, '2020-08-16 15:12:30', 0, '');
INSERT INTO `sl_order` VALUES (48, '48', 3, 2, 1.00, 423.00, '2020-08-02', '中通', '2020-08-16', 423.00, 1, 1, '2020-08-16 15:13:29', 1, '');
INSERT INTO `sl_order` VALUES (49, '49', 3, 2, 1.00, 423.00, '2020-07-28', '1', '2020-08-16', 423.00, 1, 1, '2020-08-16 15:15:43', 3, NULL);

-- ----------------------------
-- Table structure for sl_reject
-- ----------------------------
DROP TABLE IF EXISTS `sl_reject`;
CREATE TABLE `sl_reject`  (
  `id` int NOT NULL COMMENT '编号',
  `no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '退货单号',
  `order_id` int NULL DEFAULT NULL COMMENT '订单号',
  `sale_order_id` int NULL DEFAULT NULL COMMENT '销售单号',
  `customer_id` int NULL DEFAULT NULL COMMENT '客户',
  `product_id` int NULL DEFAULT NULL COMMENT '产品',
  `reject_date` date NULL DEFAULT NULL COMMENT '退单日期',
  `nums` decimal(18, 2) NULL DEFAULT NULL COMMENT '数量',
  `amount` decimal(18, 2) NULL DEFAULT NULL COMMENT '金额',
  `amount_way` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '结算方式',
  `handle_id` int NULL DEFAULT NULL COMMENT '经手人',
  `operator_id` int NULL DEFAULT NULL COMMENT '操作人',
  `operator_time` datetime(0) NULL DEFAULT NULL COMMENT '操作时间',
  `approval_status` int NULL DEFAULT NULL COMMENT '审批状态',
  `return_status` int NULL DEFAULT NULL COMMENT '退单状态',
  `remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_sl_reject_ac_staff`(`handle_id`) USING BTREE,
  INDEX `FK_sl_reject_ac_staff1`(`operator_id`) USING BTREE,
  INDEX `FK_sl_reject_pr_product`(`product_id`) USING BTREE,
  INDEX `FK_sl_reject_sl_customer`(`customer_id`) USING BTREE,
  INDEX `FK_sl_reject_sl_order`(`order_id`) USING BTREE,
  INDEX `FK_sl_reject_sl_sale_order`(`sale_order_id`) USING BTREE,
  CONSTRAINT `FK_sl_reject_ac_staff` FOREIGN KEY (`handle_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_sl_reject_ac_staff1` FOREIGN KEY (`operator_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_sl_reject_pr_product` FOREIGN KEY (`product_id`) REFERENCES `pr_product` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_sl_reject_sl_customer` FOREIGN KEY (`customer_id`) REFERENCES `sl_customer` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_sl_reject_sl_order` FOREIGN KEY (`order_id`) REFERENCES `sl_order` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_sl_reject_sl_sale_order` FOREIGN KEY (`sale_order_id`) REFERENCES `sl_sale_order` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sl_reject
-- ----------------------------

-- ----------------------------
-- Table structure for sl_sale_order
-- ----------------------------
DROP TABLE IF EXISTS `sl_sale_order`;
CREATE TABLE `sl_sale_order`  (
  `id` int NOT NULL COMMENT '编号',
  `no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '销售编号',
  `product_id` int NULL DEFAULT NULL COMMENT '产品',
  `customer_id` int NULL DEFAULT NULL COMMENT '客户编号',
  `order_id` int NULL DEFAULT NULL COMMENT '订单',
  `sale_date` date NULL DEFAULT NULL COMMENT '销售日期',
  `nums` decimal(18, 2) NULL DEFAULT NULL COMMENT '销售数量',
  `amount` decimal(18, 2) NULL DEFAULT NULL COMMENT '总金额',
  `amount_way` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '结算方式',
  `amount_receivable` decimal(18, 2) NULL DEFAULT NULL COMMENT '应收金额',
  `amount_received` decimal(18, 2) NULL DEFAULT NULL COMMENT '实收金额',
  `handle_id` int NULL DEFAULT NULL COMMENT '经手人',
  `operator_id` int NULL DEFAULT NULL COMMENT '操作人',
  `operator_time` datetime(0) NULL DEFAULT NULL COMMENT '操作时间',
  `audit_status` int NULL DEFAULT NULL COMMENT '审批状态  0待审批  1已审批  -1审批不通过',
  `order_status` int NULL DEFAULT NULL COMMENT '0待提货  1 已出库',
  `Remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_sl_sale_order_ac_staff`(`handle_id`) USING BTREE,
  INDEX `FK_sl_sale_order_ac_staff1`(`operator_id`) USING BTREE,
  INDEX `FK_sl_sale_order_pr_product`(`product_id`) USING BTREE,
  INDEX `FK_sl_sale_order_sl_customer`(`customer_id`) USING BTREE,
  INDEX `FK_sl_sale_order_sl_order`(`order_id`) USING BTREE,
  CONSTRAINT `FK_sl_sale_order_ac_staff` FOREIGN KEY (`handle_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_sl_sale_order_ac_staff1` FOREIGN KEY (`operator_id`) REFERENCES `ac_staff` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_sl_sale_order_pr_product` FOREIGN KEY (`product_id`) REFERENCES `pr_product` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_sl_sale_order_sl_customer` FOREIGN KEY (`customer_id`) REFERENCES `sl_customer` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_sl_sale_order_sl_order` FOREIGN KEY (`order_id`) REFERENCES `sl_order` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sl_sale_order
-- ----------------------------
INSERT INTO `sl_sale_order` VALUES (1, '32789673793', 1, 1, 1, '2020-08-11', 100.00, 40000.00, '顺丰', 4000.00, 0.00, 1, 1, '2020-08-11 17:22:24', 3, 3, NULL);
INSERT INTO `sl_sale_order` VALUES (17, '17', 1, 1, 17, '2020-08-15', 1000.00, 5400000.00, '现金', 5400000.00, 0.00, 1, 1, '2020-08-16 14:48:29', 0, 0, '');
INSERT INTO `sl_sale_order` VALUES (43, '43', 1, 1, 43, '2020-08-04', 666.00, 3596400.00, '微信', 3596400.00, 0.00, 1, 1, '2020-08-16 00:00:06', 1, 1, '');
INSERT INTO `sl_sale_order` VALUES (44, '44', 1, 1, 44, '2020-08-15', 1.00, 423.00, '现金', 423.00, 0.00, 1, 1, '2020-08-16 14:40:51', 1, 1, '');
INSERT INTO `sl_sale_order` VALUES (45, '45', 1, 1, 45, '2020-08-15', 45.00, 243000.00, '微信', 243000.00, 243000.00, 1, 1, '2020-08-16 15:00:46', 1, 3, '');
INSERT INTO `sl_sale_order` VALUES (48, '48', 1, 1, 48, '2020-08-03', 1.00, 423.00, '银行卡', 423.00, 0.00, 1, 1, '2020-08-16 15:14:47', 1, 1, '');
INSERT INTO `sl_sale_order` VALUES (49, '49', 1, 1, 49, '2020-08-17', 1.00, 423.00, '微信', 423.00, 423.00, 1, 1, '2020-08-16 15:15:55', 1, 3, '');

-- ----------------------------
-- Table structure for sys_config_item
-- ----------------------------
DROP TABLE IF EXISTS `sys_config_item`;
CREATE TABLE `sys_config_item`  (
  `id` int NOT NULL COMMENT '编号',
  `keyword` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '关键字',
  `table_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '表名',
  `field_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '字段名',
  `option_value` int NULL DEFAULT NULL COMMENT '值',
  `option_text` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '文本',
  `sorting` int NULL DEFAULT NULL COMMENT '排序',
  `status` int NULL DEFAULT NULL COMMENT '状态',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_config_item
-- ----------------------------

SET FOREIGN_KEY_CHECKS = 1;
