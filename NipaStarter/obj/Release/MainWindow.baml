   M S B A M L   `   `   `  ���� F  BNipaStarter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:NipaStarterNipaStarter      NipaStarter.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:NipaStarter       � Title$  NipaStarter (ver. 2)��$	��350��$	��525�� � 
ResizeMode$ NoResize=�.��� ���	#FFFD9742 � ColumnDefinitions �� $	��53* ��� $��9* ��� $	��28* ��� $
��429* �.+��� -    ��Name$ 	textBlock��$
��Left=�$��	10,48,0,0q�$
��Wrap=�$	��Top=�$	��190��$��Application Path��$��4���� -    ��Name$ textBox_appPath��$��23��$��
10,69,10,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��4���� -   $ textBlock_Copy2��$��	10,0,0,10q�$
��Wrap=�$��65��$��Bottom=�$
��Left=�$	��370��$��4���� $�Start App via OSC���� �� $�
Port: 2828���� $�2���� �� $�
Address:  ���� ���	#FFA31515$��12.6666666666667(�$��Consolas)�.��� $�/nipa/starter���� �� $�
Arguments:���� $� ���� ���	#FFA31515$��12.6666666666667(�$��Consolas)�.��� $�STARTAPP���� -    ��Name$ Button_start��$��Start Application��$��
10,10,10,0q�$	��Top=�$��34��$��4���� -   $ textBox_width��$��23��$��2,99,0,0q�$
 Wrap=�$	��Top=�$
��Left=�$	��126��$��3���� -   $ textBlock_Copy��$
��Left=�$��
10,101,0,0q�$
��Wrap=�$	��Top=�$��83��$��Screen Width��$��4���� -   $ textBlock_Copy1��$��148,101,0,0q�$
��Wrap=�$	��Top=�$
��Left=�$��3���� $�Screen ���� $�Height���� -   $ textBox_height��$��23��$��	0,99,70,0q�$
 Wrap=�$	��Top=�$��Right=�$	��126��$��3���� -	   $ button_apply��$��Apply & Save��$��
0,286,10,0q�$	��Top=�$��25��$��Right=�$	��164��$��3���� -
   $ textBox_unityLogPath��$��23��$��10,183,10,0q�$
 Wrap=�$	��Top=�$��4���� -   $ textBlock_Copy3��$��
10,158,0,0q�$
��Wrap=�$7��1Unity Log File Directry (empty for no log output)��$
��Left=�$	��Top=�$��22��$��4���� -    ��Name$ checkBox_awakeStart��$��Start App when Awake��$
��Left=�$��	10,0,0,83q�$��Bottom=�$��4���� -   $ checkBox_killExplorer��$"��Kill Explorer When App Start��$��	83,0,0,83q�$��Bottom=�$
��Left=�$��3���� -   $ textBlock_Copy4��$��Right=�$��	0,122,9,0q�$
��Wrap=�$	��Top=�$	��159��$ ��*Unity must be window mode��$��3���� -   $ button_openLogDir��$��Open Log Dir��$��
0,153,10,0q�$	��Top=�$��25��$��Right=�$	��164��$��3��