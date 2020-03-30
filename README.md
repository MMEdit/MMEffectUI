# MMEffectUI

<a href="https://github.com/MMEdit/MMEffectUI/releases"><img alt="Downloads" src="https://img.shields.io/github/downloads/MMEdit/MMEffectUI/total?style=flat-square"/></a> <a href="https://github.com/nicengi/MMEdit/releases"><img alt="Downloads@MMEdit" src="https://img.shields.io/github/downloads/nicengi/MMEdit/total?label=downloads%40MMEdit&style=flat-square"/></a> <a href="https://github.com/MMEdit/MMEffectUI/blob/master/LICENSE"><img alt="License" src="https://img.shields.io/github/license/MMEdit/MMEffectUI?color=39c5bb&style=flat-square"></a>

一个 [MMEdit](https://github.com/nicengi/MMEdit) 插件，提供包含 UI 注解的 [MME](https://bowlroll.net/file/35012) 效果文件的导入、导出和小部件。

## 使用说明

​	要使程序可以识别和编辑一个对象，你需要为其添加 UI 注解（在尖括号内）。**一些效果文件已经包含了这部分代码。**

![20200202225843](./docs/Images/20200202225843.png)

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

