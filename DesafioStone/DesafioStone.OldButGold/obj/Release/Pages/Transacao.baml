   M S B A M L   `   `   `  ���� R  NDesafioStone.OldButGold, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:DesafioStone.OldButGold.PagesDesafioStone.OldButGold.Pages  -    'DesafioStone.OldButGold.Pages.Transacao   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =local+clr-namespace:DesafioStone.OldButGold.Pages       N� Title$  	Transacao��.���  � ColumnDefinitions �� $	��300 � � RowDefinitions �� $
��Auto ��� $
��Auto �.+��� $��0��   headerTextStyle#��[  .��Nova Transação� $��10q�$��0��$��1�� �� ��  �� $
��Auto ��� $
��Auto ��� �� �� �� �� �� .+��� $��0��$��2��$��0�� �� Orientation$ 
Horizontal=�.+���   
labelStyle#��[ .��Cliente Cadastrado:�� $��1��$��2��$��0��$ 
Horizontal=�.+��� -   $��
ClientName��  comboBoxStyle#��[ �� $��0��$��2��$��1��$ 
Horizontal=�.+��� #��[ .��Cartão Cadastrado:�� $��1��$��2��$��1��$ 
Horizontal=�.+��� -   $��
CardNumber��#��[ �� $��0��$��2��$��2��$ 
Horizontal=�.+��� #��[ .��Valor da Transação:�� $��1��$��2��$��2��$ 
Horizontal=�.+��� -   $��Amount��  textBoxStyle#��[ �� $��0��$��2��$��3��$ 
Horizontal=�.+��� #��[ .��Tipo de Cartão:�� $��1��$��2��$��3��$ 
Horizontal=�.+��� -   $
��Type��#��[  �� SelectedIndex$ 0��.@��� $��-- Selecione --���� $��Débito���� $��Crédito���� $��0��$��2��$��4��$ 
Horizontal=�.+��� #��[ .��	Parcelas:�� $��1��$��2��$��4��$ 
Horizontal=�.+��� -   $��Number��#��[ $ 0��$
��Auto��$��0,0,0,8q�$��Stretch=�.@��� 
 � Tag$ 0��$��-- Selecione --���� $ 5��$��5���� $ 4��$��4���� $ 3��$��3���� $ 2��$��2���� $ 1��$��1���� $��0��$��2��$��5��$ 
Horizontal=�.+��� -     buttonStyle#��[ .��Salvar�� $��1��$��2��$��5��$ 
Horizontal=�.+��� -   #��[ .��
Cancelar