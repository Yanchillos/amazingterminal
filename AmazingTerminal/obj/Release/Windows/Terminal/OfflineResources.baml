   M S B A M L   `   `   `  ���� J  FAmazingTerminal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Nclr-namespace:AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Headers@AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Headers  �Kclr-namespace:AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Rows=AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Rows  �Fclr-namespace:AmazingTerminal.Windows.Terminal.Controls.Offline.Models8AmazingTerminal.Windows.Terminal.Controls.Offline.Models  G(clr-namespace:AmazingTerminal.ConvertersAmazingTerminal.Converters  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35:    4AmazingTerminal.Converters.BoolToVisibilityConverter   BoolToVisibilityConverter  �� 
TargetType  sportbookSportButtonStyle �� Property �� Value �� 
TargetType �� CornerRadius �� Padding  sportbookCountryButtonStyle  sportbookLeagueButtonStyle �� DataTypeE   ?AmazingTerminal.Windows.Terminal.Controls.Offline.Models.League  sportbookLeagueTemplate � ColumnDefinitions d� 	IsChecked.  (System.Windows.Interactivity.Interaction	   Triggers/  )System.Windows.Interactivity.EventTrigger
   	EventName.  (System.Windows.Interactivity.TriggerBase   Actions6  0System.Windows.Interactivity.InvokeCommandAction   Command �� ElementName �� Path   CommandParameterF   @AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Country  sportbookCountryTemplate � RowDefinitions �� 	ConverterD   >AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Sport  sportbookSportTemplateG   AAmazingTerminal.Windows.Terminal.Controls.Offline.Models.BetGroup  viewBetGroupButtonTemplateS	   MAmazingTerminal.Windows.Terminal.Controls.Offline.Models.Headers.DoubleHeader  viewDoubleHeaderTemplate �� TextAlignmentT
   NAmazingTerminal.Windows.Terminal.Controls.Offline.Models.Headers.TernaryHeader 	 viewTernaryHeaderTemplate\   VAmazingTerminal.Windows.Terminal.Controls.Offline.Models.Headers.DoubleWithPointHeader %
 !viewDoubleWithPointHeaderTemplate`   ZAmazingTerminal.Windows.Terminal.Controls.Offline.Models.Headers.DoubleWithTwoPointsHeader ) %viewDoubleWithTwoPointsHeaderTemplateM   GAmazingTerminal.Windows.Terminal.Controls.Offline.Models.Headers.Header  viewHeaderTemplate �� Triggers �� Binding �� ValueM   GAmazingTerminal.Windows.Terminal.Controls.Offline.Models.Rows.DoubleRow  viewDoubleRowTemplate �� StringFormatN   HAmazingTerminal.Windows.Terminal.Controls.Offline.Models.Rows.TernaryRow  viewTernaryRowTemplateV   PAmazingTerminal.Windows.Terminal.Controls.Offline.Models.Rows.DoubleWithPointRow " viewDoubleWithPointRowTemplateZ   TAmazingTerminal.Windows.Terminal.Controls.Offline.Models.Rows.DoubleWithTwoPointsRow & "viewDoubleWithTwoPointsRowTemplateM   GAmazingTerminal.Windows.Terminal.Controls.Offline.Models.Rows.CustomRow  viewCustomRowTemplateG   AAmazingTerminal.Windows.Terminal.Controls.Offline.Models.Rows.Row  viewRowTemplateF   @AmazingTerminal.Windows.Terminal.Controls.Offline.Models.BetType  viewCommonBetTypeTemplate  viewCustomBetTypeTemplate  viewBetTypeTemplate  viewBetGroupTemplateD   >AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Event  overviewEventTemplate J� InputBindings d� MouseAction �� Command �� CommandParameter  overviewLeagueTemplate�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     Bi:http://schemas.microsoft.com/expression/2010/interactivity  ZheadersNclr-namespace:AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Headers  TrowsKclr-namespace:AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Rows  QmodelsFclr-namespace:AmazingTerminal.Windows.Terminal.Controls.Offline.Models  7
converters(clr-namespace:AmazingTerminal.Converters  %.  &	        &	      &	 l     &	 �     &	 :    7  &	 �    7  7  7   &	 �    7  7  7   &	 �    &	     &		 �    &	
 �    &	      &	 �	    7  7 	 7  7 
 &	 �
    &	 �    &	 T    &	 �    &	 �    &	 L    7  7  7  7  7  &	 �    7  7  &	 �    7  7  7  &	 l    7  7  &	     7  &	 �    7  &	 �    7  7     �� "  �����  � �� �� " ��.R��� $ 5��
������$��2,1.5q�$ 5q�._��� #��z���� "  �����  � �� �� " ��.R��� $ 5��
���� ��$��2,1.5q�$ 5q�._��� #��z���� "  �����  � �� �� " ��.R��� $ 5��
����ح�$��2,1.5q�$ 5q�._��� #��z���� "  .R��  �� $
��Auto ��� $��* �.+��� $��0��$��Center=�$	��2,0q� �� *
IsSelected+	   $
 Checked��.    �� $
 root��$&  DataContext.LeagueCheckedCommand� ��   $
 	Unchecked��.    �� $
 root��$( "DataContext.LeagueUncheckedCommand� �� �� $��1��8��  ���� *Name+���� $
 root��$' !DataContext.LeagueUIActionCommand����� �� "  .R��  �� $
��Auto ��� $��* �.+��� $��0��8��  ���� *Name+���� $
 root��$( "DataContext.CountryUIActionCommand����� �� $��1��8�� ���� *	Leagues+y��� *IsOpen+8  �� "  .R��  �� $
��Auto ��� $��* �.+��� $��0��8��  ���� *Name+���� $
 root��$&  DataContext.SportUIActionCommand����� �� $��1��8�� ���� *	Countries+y��� *IsOpen+8  �� "  .R��� $��10q�$��14(����� *Name+���� $
 root��$&  DataContext.BetGroupClickCommand����� �� " 	 .R��  �� $��* ��� $��* �.+��� $��0��
���  ��$��16(�$��1q�$ Center=����� *	Column1+�� $��1��
���  ��$��16(�$��1q�$ Center=����� *	Column2+�� " 
 .R��  �� $��* ��� $��* ��� $��* �.+��� $��0��
���  ��$��16(�$��1q�$ Center=����� *	Column1+�� $��1��
���  ��$��16(�$��1q�$ Center=����� *	Column2+�� $��2��
���  ��$��16(�$��1q�$ Center=����� *	Column3+�� "  .R��  �� $��* ��� $��* ��� $��* �.+��� $��0��
���  ��$��16(�$��1q�$ Center=����� *	Column1+�� $��1��
���  ��$��16(�$��1q�$ Center=����� *	Column2+�� $��2��
���  ��$��16(�$��1q�$ Center=����� *	Column3+�� "  .R��  �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��
���  ��$��16(�$��1q�$ Center=����� *	Column1+�� $��1��
���  ��$��16(�$��1q�$ Center=����� *	Column2+�� $��2��
���  ��$��16(�$��1q�$ Center=����� *	Column3+�� $��3��
���  ��$��16(�$��1q�$ Center=����� *	Column4+�� "  .R��� ���� ���� "  �� ��  �� *
ViewTypeId+ 1.a���  � ��8   ��  �� *
ViewTypeId+ 2.a���  � ��8  ��  �� *
ViewTypeId+ 3.a���  � ��8  ��  �� *
ViewTypeId+ 12.a���  � ��8  �� "  .R��  �� $��* ��� $��* �.+��� $��0��$ 5q�$��2q�
���  ��$��1q�._��� 
���  ��$��16(�$ Center=����� *F1+$ N2���� $��1��$ 5q�$��2q�
���  ��$��1q�._��� 
���  ��$��16(�$ Center=����� *F2+$ N2���� "  .R��  �� $��* ��� $��* ��� $��* �.+��� $��0��$ 5q�$��2q�
���  ��$��1q�._��� 
���  ��$��16(�$ Center=����� *F1+$ N2���� $��1��$ 5q�$��2q�
���  ��$��1q�._��� 
���  ��$��16(�$ Center=����� *FX+$ N2���� $��2��$ 5q�$��2q�
���  ��$��1q�._��� 
���  ��$��16(�$ Center=����� *F2+$ N2���� "  .R��  �� $��* ��� $��* ��� $��* �.+��� $��0��$ 5q�$��2q�
���  ��$��1q�._��� 
���  ��$��16(�$ Center=����� *F1+$ N2���� $��1��$ 5q�$��1q�._��� 
���  ��$��16(�$ Center=����� *Point+$ N2���� $��2��$ 5q�$��2q�
���  ��$��1q�._��� 
���  ��$��16(�$ Center=����� *F2+$ N2���� "  .R��  �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$ 5q�$��2q�
���  ��$��1q�._��� 
���  ��$��16(�$ Center=����� *F1+$ N2���� $��1��$ 5q�$��1q�._��� 
���  ��$��16(�$ Center=����� *P1+$ N2���� $��2��$ 5q�$��2q�
���  ��$��1q�._��� 
���  ��$��16(�$ Center=����� *F2+$ N2���� $��3��$ 5q�$��1q�._��� 
���  ��$��16(�$ Center=����� *P2+$ N2���� "  .R��� $��1��$ 5q�$��2q�
���  ��$��1q�._��� 
���  ��$��16(�$ Center=����� *Factor+$ N2���� "  .R��� ���� ���� "  �� ��  �� *
ViewTypeId+ 1.a���  � ��8   ��  �� *
ViewTypeId+ 2.a���  � ��8  ��  �� *
ViewTypeId+ 3.a���  � ��8  ��  �� *
ViewTypeId+ 5.a���  � ��8  ��  �� *
ViewTypeId+ 12.a���  � ��8  �� "  .R��  �� $
��Auto ��� $
��Auto � �� $
��Auto ��� $��* ��� $	��300 �.+��� $��0��$��0��
���  ��$��16(����� *Name+�� $��0��$��2��8��  ���� *Header+�� $��1��$��2��8�� ���� *Rows+�� "  .R��  �� $��* ��� $��* ��� $��* �.+��� $��0��8��  ���� *GetCustomColumn1Rows+�� $��1��8�� ���� *GetCustomColumn2Rows+�� $��2��8�� ���� *GetCustomColumn3Rows+�� "  .R��� ���� ���� "  �� ��  �� *
IsCustom+	 False.a���  � ��8   ��  �� *
IsCustom+ True.a���  � ��8  �� "  .R��� $��1��$
��Auto=�.���  �� $
��Auto ��� $
��Auto �.+��� $��0��
��� � �$��18(����� *Name+�� $��1��8��  ���� *
BetTypes+�� "  .R��  �� $
��Auto ��� $
��Auto ��� $��* ��� $	��300 ��� $��75 �.+��� $��0��
��� � �$��16(�$��0,0,10,0q����� *Code+�� $��1��
��� � �$��16(����� *	EventName+�� $��3��8��  ���� *MainBetTypeRow+�� $��4��$ 5q�$��2q�
���  ��$��1q�._��� 
��� � �$��16(�$ Center=����� *	OddsCount+$
 +{0}�� d� $ 	LeftClicke� �� $
 root��$$ DataContext.SelectEventCommand� �� �� "  .R��  �� $
��Auto ��� $
��Auto � �� $
��Auto ��� $��* ��� $	��300 ��� $��75 �.+��� $��0��$��0��$��16(�
���  ������ *Name+�� $��0��$��2��8��  ���� *Events[0].MainBetGroupHeader+�� $��1��$��0��$��4��8�� ���� *Events+