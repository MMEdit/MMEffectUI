# MMDUI

<a href="https://github.com/MMEdit/MMDUI/releases"><img alt="Downloads" src="https://img.shields.io/github/downloads/MMEdit/MMDUI/total?style=flat-square"/></a><a href="https://github.com/nicengi/MMEdit/releases"><img alt="Downloads@MMEdit" src="https://img.shields.io/github/downloads/nicengi/MMEdit/total?label=downloads%40MMEdit&style=flat-square"/></a><a href="https://github.com/MMEdit/MMDUI/blob/master/LICENSE"><img alt="License" src="https://img.shields.io/github/license/MMEdit/MMDUI?color=39c5bb&style=flat-square"></a>

一个 [MMEdit](https://github.com/nicengi/MMEdit) 插件，提供 MMDUI 格式的 [MME](https://bowlroll.net/file/35012)文件的导入、导出和小部件。

## 使用说明

​	要使程序可以识别和编辑一个对象（变量），你需要为其添加注释（在尖括号内的变量）。**部分 MME 已经包含了这部分代码**，则无需手动添加。

![20200202225843](.\doc\Images\20200202225843.png)

### UI Annotations

| 名称      | 描述                             | 必须   | 默认值 |
| --------- | -------------------------------- | ------ | :----: |
| UIName    | 小部件的标题。                   | 否     |  N/A   |
| UIWidget  | 对象所使用的[小部件](#Widgets)。 | **是** |  N/A   |
| UIHelp    | 提示文本。                       | 否     |  N/A   |
| UIVisible | 指示是否显示控件。               | 否     |  true  |
| UIMin     | 指示对象的最小值。               | 否     |   0    |
| UIMax     | 指示对象的最大值。               | 否     | 10000  |

### Widgets

| 名称    | 描述                                  |
| ------- | ------------------------------------- |
| Slider  | 滑块控件。                            |
| Numeric | 带上/下按钮的数值文本框。             |
| Spinner | 带上/下按钮的数值文本框。             |
| Color   | 颜色滑块，支持编辑 RGB 或 RGBA 颜色。 |

