   M S B A M L   `   `   `  ���� R  NDesafioStone.OldButGold, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:DesafioStone.OldButGold.PagesDesafioStone.OldButGold.Pages  2    ,DesafioStone.OldButGold.Pages.CadastroCartao   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =local+clr-namespace:DesafioStone.OldButGold.Pages       N� Title$  CadastroCartao��.���  � ColumnDefinitions �� $	��300 � � RowDefinitions �� $
��Auto ��� $
��Auto �.+��� $��0��   headerTextStyle#��[  .��Cadastro de Cartões� $��10q�$��0��$��1�� �� ��  �� $
��Auto ��� $
��Auto ��� �� �� �� �� �� .+��� $��0��$��2��$��0�� �� Orientation$ 
Horizontal=�.+���   
labelStyle#��[ .��Nome no Cartão:�� $��1��$��2��$��0��$ 
Horizontal=�.+��� -   $��CardholderName��  textBoxStyle#��[ �� $��0��$��2��$��1��$ 
Horizontal=�.+��� #��[ .��Número do Cartão:�� $��1��$��2��$��1��$ 
Horizontal=�.+��� -   $��Number��#��[ �� $��0��$��2��$��2��$ 
Horizontal=�.+��� #��[ .��Data de Expiração:�� $��1��$��2��$��2��$ 
Horizontal=�.+�(  "System.Windows.Controls.DatePicker  -   $��ExpirationDate��  datePickerStyle#��[ �� $��0��$��2��$��3��$ 
Horizontal=�.+��� #��[ .��Bandeira do Cartão:�� $��1��$��2��$��3��$ 
Horizontal=�.+��� -   $��	CardBrand��  comboBoxStyle#��[  �� SelectedIndex$ 0��.@��� $��-- Selecione --���� $
��Visa���� $��
MasterCard���� $��0��$��2��$��4��$ 
Horizontal=�.+��� #��[ .��Senha:�� $��1��$��2��$��4��$ 
Horizontal=�.+�G� -   $��Password��  passwordStyle#��[ �� $��0��$��2��$��5��$ 
Horizontal=�.+��� #��[ .��Tipo de Cartão:�� $��1��$��2��$��5��$ 
Horizontal=�.+��� -   $
��Type��#��[ $ 0��.@��� $��-- Selecione --���� $
��Chip���� $��Tarja Magnética���� $��0��$��2��$��6��$ 
Horizontal=�.+��� #��[ .��Cliente Cadastrado:�� $��1��$��2��$��6��$ 
Horizontal=�.+��� -   $��
ClientName��#��[ �� $��0��$��2��$��7��$ 
Horizontal=�.+��� -     buttonStyle#��[ .��Salvar�� $��1��$��2��$��7��$ 
Horizontal=�.+��� -	   #��[ .��
Cancelar