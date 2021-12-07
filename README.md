# PopMessage
Pop Message is a tool for convenient pop-up text output. This asset allows you to quickly and beautifully design pop-up messages without affecting performance!    

**Easy to execute. You just need to call `ShowMassage` in `PopMessageManager`**.

![PopMessage](https://media3.giphy.com/media/gculzY1HUWoV3Wx5Oz/giphy.gif?cid=790b7611bceaf7b75cc4bf6d7c2dfe6ab9c56b03fc08b207&rid=giphy.gif)
# Instruction
To create a message, we need to follow a few steps:
## 1. Installation
Download the latest version and install in your project.

[![GitHub releases](https://img.shields.io/static/v1?style=for-the-badge&label=GitHub%20Releases&labelColor=181717&message=Downloads&color=green&logo=GitHub&logoColor=white)](https://github.com/Laskka/PopMessage/releases)

:capital_abcd: If you want to use this plugin with TMPro, then you need to add `POP_MESSAGE_TMPRO` to Scripting Define Symbols `Project Settings > Player > Other Settings > Scripting Define Symbols`

## 2. Create PopMessage
Create a text and customize its appearance to suit your needs. Add `PopMessage` script to the text.
The `PopMessage` script has 4 parameters:

1. MovingCurve
2. FadeCurve
3. Duration
4. Distance

## 3. Create PopManager
Create a new canvas and add `PopMessageManager` script and customize the canvas for your project.    
The `PopMessageManager` script has 3 parameters:

1. Pool - The amount of objects in the pool.
2. Prefab - The `PopMessage` prefab is a previously created.
3. Do DontDestroyOnLoad - Make this object DontDestroyOnLoad.


