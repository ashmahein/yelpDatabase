   M S B A M L   `   `   `  ����E  AMilestone1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Milestone1
Milestone1  5   	       Milestone1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Milestone1     5   	     � Title$
  Yelp��5   	   $	��740��6   $
��1058��6#   $��16(�60   .��5	      � .+�5
   
   �� $��2,0,-1.8,0.4q�6   
������� � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName��%J  '��       �� 5      " ��6   .�5      ��  � �� 5      �� 5      " ��6.   .R�5   "   �� $��Border��6)   $��1,1,1,0q�67   
�������$ 4,4,0,0��6i   $	��2,0q�6�   ._�5   &   �� $ ContentSite��67   $��Center=�5   )   $��Center=�5   )   $��Header��5   )   $
��10,2q�5   )   5   #    5   "   P� 5   &   	 �@��
IsSelected
 . . �5   *   �� $ Border��61    � ��
 ��·�6[   5   '   P� 5   &   	 �@��
IsSelected
 .  . �5   *   �� $ Border��61    � ��
 �����6[   5   '   5      5!      5"      5#      .@�5$      �� $��Search Business��6   .��5%      � .+�5&      �� -   5         ��Name$ State_CityGroupBox��5&      $��Select Location��6;   $
��Left=�6T   $	��650��6o   $��8,10,0,0q�6|   $	��Top=�6�   $	��211��6�   .��5'      � $��0,0,-2,0q�6   .+�5(      �� -   5         ��Name$ 
stateLabel��5(   $   $��State��68   $
��Left=�6H   $��27��6c   $	��Top=�6o   $��38��6�   $��12(�6�    J� RenderTransformOrigin$ -0.702,-0.75&�6�   �� 5)      -   5         ��Name$ stateComboBox��5)   '   $
��Left=�6>   $��32��6Y   $��43,0,0,0q�6e   $	��Top=�6w   $	��135��6�   $��12(�6�   �� 5*      -   5        $��	cityLabel��5*   $   $
��City��66   $
��Left=�6E   $��0,27,0,0q�6`   $	��Top=�6r   $��38��6�   $ -0.294,-0.625&�6�   $��12(�6�   �� 5+      -   5        $ zipcodeLabel��5+   $   $��Zip Code��6;   $
��Left=�6N   $��	0,141,0,0q�6i   $	��Top=�6|   $��73��6�   $ -0.294,-0.625&�6�   $��12(�6�   �� 5,      -   5         ��Name$ cityListBox��5,   &   $��Center=�6;   $��88��6X   $��8,53,8,0q�6d   $	��Top=�6v   $	��185��6�   $��12(�6�   �� 5-      -   5        $��zipCodeListBox��5-   &   $��Center=�6<   $��88��6Y   $	��Top=�6e   $	��185��6}   $��
10,167,6,0q�6�   $��12(�6�   �� 5.      -   5        $ CategoryListBox��5.   &   $��Center=�6?   $	��170��6\   $��	8,281,8,0q�6i   $	��Top=�6|   $	��185��6�   $��12(�6�   �� 5/      -	   5        $��businessCategory��5/   $   $��Business Category��6=   $
��Left=�6Y   $��	0,255,0,0q�6t   $	��Top=�6�   $ 0.417,-0.008&�6�   $��12(�6�   �� 50      -
   5        $��	addButton��50   %   $	��Add��66   $
��Left=�6D   $��
10,456,0,0q�6_   $	��Top=�6s   $ 0.417,-0.008&�6�   $��12(�6�   $��80��6�   6�   �� 51      -   5        $��removeButton��51   %   $��Remove��69   $
��Left=�6J   $��111,456,0,0q�6e   $	��Top=�6z   $ 0.417,-0.008&�6�   $��12(�6�   $��80��6�   6�   �� 52      -   5        $ SelectedCategories��52   &   $��Center=�6B   $	��114��6_   $��	9,481,9,0q�6l   $	��Top=�6   $	��183��6�   $��12(�6�   6�   �� 53      -   5        $��searchButton��53   %   $��Search Business��69   $��Center=�6S   $��	9,600,9,0q�6p   $	��Top=�6�   $ 0.417,-0.008&�6�   $��12(�6�   $	��183��6�   6�   54      55      �� 56      -   5        $��openBusinessGroupBox��56      $��Open Business��6;   $
��Left=�6R   $��224,10,0,599q�6m   $	��516��6�   $��1q�6�   .��57      � .+�58      �� -   5        $ dowLabel��58   $   $��Day Of Week��66   $
��Left=�6L   $��28��6g   $��Center=�6s   $��92��6�   $��12(�6�   $ -0.702,-0.75&�6�   �� 59      -   5        $ toLabel��59   $   $
��From��65   $
��Left=�6D   $��28��6_   $��Center=�6k   $��42��6�   $��12(�6�   $ -0.702,-0.75&�6�   $��	217,0,0,0q�6�   �� 5:      -   5        $ 	fromLabel��5:   $   $��To��67   $
��Left=�6D   $��28��6_   $��Center=�6k   $��24��6�   $��12(�6�   $ -0.702,-0.75&�6�   $��	369,0,0,0q�6�   �� 5;      -   5        $ dowComboBox��5;   '   $
��Left=�6<   $��32��6W   $��	92,-4,0,0q�6c   $��Center=�6v   $	��120��6�   $��12(�6�   �� 5<      -   5        $ FromComboBox��5<   '   $
��Left=�6=   $��32��6X   $��
264,-4,0,0q�6d   $��Center=�6x   $	��100��6�   $��12(�6�   �� 5=      -   5        $ 
ToComboBox��5=   '   $
��Left=�6;   $��32��6V   $��
398,-4,0,0q�6b   $��Center=�6v   $	��100��6�   $ 0.528,1&�6�   $��12(�6�   5>      5?      �� 5@      -   5        $��searchResultGroupBox��5@      $��SearchResults��6;   $
��Left=�6R   $��224,81,0,162q�6m   $	��595��6�   $��1q�6�   .��5A      � .+�5B      �� -   5        $ numOfBusinessLabel��5B   $   $��# of Businesses��6@   $
��Left=�6Z   $��23��6u   $	��Top=�6�   $	��104��6�   $��10(�6�   $ -0.702,-0.75&�6�   &   System.Windows.Controls.DataGrid  5C      -   5        $��displayGrid��5C   '   $
��Left=�6:   $	��381��6U   $	��Top=�6b   $	��583��6z   $��0,23,0,0q�6�   $��12(�6�   6�   5D      5E      �� 5F      -   5        $��selectBusinessGroupBox��5F      $��Select Businesses��6=   $
��Left=�6X   $��224,518,0,15q�6s   $	��595��6�   $��1q�6�   .��5G      � .+�5H      �� -   5         ��Name$ businessNameTextBox��5H   &   $
��Left=�6C   $��28��6^   $��10,0,0,0q�6j    �� TextWrapping$
 Wrap=�6|   $��Business Name��6�   $	��Top=�6�   $	��450��6�   
����ح�$��12(�6�   �� 5I      -   5        $ reviewTextBox��5I   &   $
��Left=�6=   $��71��6X   $��	10,33,0,0q�6d   $
 Wrap=�6w   $��review text��6�   $	��Top=�6�   $	��450��6�   $��12(�6�   �� 5J      -   5        $ ratingLabel��5J   $   $��Rating:��69   $
��Left=�6K   $��23��6f   $	��Top=�6r   $��53��6�   $��10(�6�   $ -0.702,-0.75&�6�   $��
465,24,0,0q�6�   �� 5K      -   5        $ ratingComboBox��5K   '   $
��Left=�6?   $��30��6Z   $��
465,47,0,0q�6f   $	��Top=�6z   $	��108��6�   $��12(�6�   6�   �� 5L      -   5        $��checkinButton��5L   %   $��Checkin��6:   $
��Left=�6L   $��465,-1,0,95q�6g   $��Bottom=�6|   $ 0.417,-0.008&�6�   $��12(�6�   $	��108��6�   
������6�   �� 5M      -   5        $��addReviewButton��5M   %   $��
Add Review��6<   $
��Left=�6Q   $��465,82,0,10q�6l   $ 0.417,-0.008&�6�   $��12(�6�   $	��108��6�   
������6�   5N      5O      �� 5P      -   5        $��priceFilterGroupBox��5P      $��Filter by Price��6:   $
��Left=�6S   $��824,10,0,582q�6n   $	��192��6�   $��1q�6�   .��5Q      � $��0,0,-2,0q�6   .+�5R      �� -    5         ��Name$ 
lessThan10��5R   '   $��$��6;   $
��Left=�6G   $��	30,10,0,0q�6b   $	��Top=�6u   $ 0.101,0.675&�6�   $��12(�6�   �� 5S      -!   5        $ lessThan100��5S   '   $��$$��6<   $
��Left=�6I   $��	30,33,0,0q�6d   $	��Top=�6w   $ 0.101,0.675&�6�   $��12(�6�   �� 5T      -"   5        $ lessThan1000��5T   '   $	��$$$��6=   $
��Left=�6K   $��
116,10,0,0q�6f   $	��Top=�6z   $ 0.101,0.675&�6�   $��12(�6�   �� 5U      -#   5        $ lessThan10000��5U   '   $
��$$$$��6>   $
��Left=�6M   $��
116,33,0,0q�6h   $	��Top=�6|   $ 0.101,0.675&�6�   $��12(�6�   5V      5W      �� 5X      -$   5        $��AttributesGroupBox��5X      $��Filter by Attributes��69   $
��Left=�6W   $��824,94,0,311q�6r   $	��192��6�   $��1q�6�   .��5Y      � .+�5Z      �� -%   5        $ creditCardAtt��5Z   '   $��Accepts Credit Cards��6>   $
��Left=�6]   $��	10,10,0,0q�6x   $	��Top=�6�   $ 0.101,0.675&�6�   $��12(�6�   �� 5[      -&   5        $ takeReservationAtt��5[   '   $��Takes Reservations��6C   $
��Left=�6`   $��	10,33,0,0q�6{   $	��Top=�6�   $ 0.101,0.675&�6�   $��12(�6�   �� 5\      -'   5        $ wheelchairAtt��5\   '   $��Wheelchair Accessible��6>   $
��Left=�6^   $��	10,56,0,0q�6y   $	��Top=�6�   $ 0.101,0.675&�6�   $��12(�6�   �� 5]      -(   5        $ 
outdoorAtt��5]   '   $��Outdoor Seating��6;   $
��Left=�6U   $��	10,79,0,0q�6p   $	��Top=�6�   $ 0.101,0.675&�6�   $��12(�6�   �� 5^      -)   5        $ kidsAtt��5^   '   $��Good for Kids��68   $
��Left=�6P   $��
10,102,0,0q�6k   $	��Top=�6   $ 0.101,0.675&�6�   $��12(�6�   �� 5_      -*   5        $ groupAtt��5_   '   $��Good for Groups��69   $
��Left=�6S   $��
10,125,0,0q�6n   $	��Top=�6�   $ 0.101,0.675&�6�   $��12(�6�   �� 5`      -+   5        $ deliveryAtt��5`   '   $��Delivery��6<   $
��Left=�6O   $��
10,148,0,0q�6j   $	��Top=�6~   $ 0.101,0.675&�6�   $��12(�6�   �� 5a      -,   5        $ 
takeOutAtt��5a   '   $��Take Out��6;   $
��Left=�6N   $��
10,171,0,0q�6i   $	��Top=�6}   $ 0.101,0.675&�6�   $��12(�6�   �� 5b      --   5        $ wifiAtt��5b   '   $��
Free Wi-Fi��68   $
��Left=�6M   $��
10,194,0,0q�6h   $ 0.101,0.675&�6|   $��12(�6�   $��15��6�   $	��Top=�6�   �� 5c      -.   5        $ bikeAtt��5c   '   $��Bike Parking��68   $
��Left=�6O   $��
10,217,0,0q�6j   $	��Top=�6~   $ 0.101,0.675&�6�   $��12(�6�   5d      5e      �� 5f      -/   5        $��mealFilterGroupBox��5f      $��Filter by Meal��69   $
��Left=�6Q   $��824,364,0,199q�6l   $	��192��6�   $��1q�6�   .��5g      � $��0,0,-2,0q�6   .+�5h      �� -0   5        $ 	Breakfast��5h   '   $��	Breakfast��6:   $
��Left=�6N   $��	10,10,0,0q�6i   $	��Top=�6|   $ 0.101,0.675&�6�   $��14(�6�   �� 5i      -1   5        $ Brunch��5i   '   $��Brunch��67   $
��Left=�6H   $��	10,33,0,0q�6c   $	��Top=�6v   $ 0.101,0.675&�6�   $��14(�6�   �� 5j      -2   5        $ Lunch��5j   '   $��Lunch��66   $
��Left=�6F   $��	10,56,0,0q�6a   $	��Top=�6t   $ 0.101,0.675&�6�   $��14(�6�   �� 5k      -3   5        $ Dinner��5k   '   $��Dinner��67   $
��Left=�6H   $��	91,10,0,0q�6c   $	��Top=�6v   $ 0.101,0.675&�6�   $��14(�6�   �� 5l      -4   5        $ Dessert��5l   '   $��Dessert��68   $
��Left=�6J   $��	91,33,0,0q�6e   $	��Top=�6x   $ 0.101,0.675&�6�   $��14(�6�   �� 5m      -5   5        $ 	LateNight��5m   '   $��
Late Night��6:   $
��Left=�6O   $��	91,56,0,0q�6j   $	��Top=�6}   $ 0.101,0.675&�6�   $��14(�6�   5n      5o      �� 5p      -6   5        $��sortByGroupBox��5p      $��Sort Results By:��65   $
��Left=�6O   $��824,481,0,130q�6j   $	��192��6�   $��1q�6�   $��12(�6�   .��5q      � $��0,0,-2,0q�6   .+�5r      �� -7   5        $ sortByComboBox��5r   '   $
��Left=�6?   $��32��6Z   $��10,0,0,0q�6f   $	��Top=�6x   $	��162��6�   $��12(�6�   5s      5t      �� 5u      -8   5        $��showGroupBox��5u      $
��Left=�63   $��824,550,0,15q�6N   $	��192��6d   $��1q�6p   $��12(�6�   .��5v      � $��0,0,-2,4q�6   .+�5w      �� -9   5        $��showCheckinButton��5w   %   $��Show Checkins��6>   $��Center=�6V   $��
10,10,10,0q�6s   $	��Top=�6�   $ 0.417,-0.008&�6�   $��14(�6�   $	��162��6�   
����� �6�   �� 5x      -:   5        $��showReviewButton��5x   %   $��Show Reviews��6=   $��Center=�6T   $��
10,39,10,0q�6q   $	��Top=�6�   $ 0.417,-0.008&�6�   $��14(�6�   $	��162��6�   
����� �6�   �� 5y      -;   5        $��numOfBusinessButton��5y   %   $��#of Business per Zipcode��6@   $��Center=�6c   $��
10,67,10,0q�6�   $	��Top=�6�   $ 0.417,-0.008&�6�   $��14(�6�   $	��162��6�   
���  ��6�   5z      5{      5|      5}      �� 5~      $��User Information��6   $��2.4,0,-1.8,0.2q�60   .��5      � .+�5�      �� -<   5        $��CurrentUserGroupUser��5�      $��Set Current User��6;   $
��Left=�6U   $��5,0,0,0q�6p   $	��350��6�   $	��134��6�   $	��Top=�6�   $��2q�6�   .��5�      � $��0,0,-0.4,-18.4q�6   .+�5�      �� -=   5        $ currentUserTextBox��5�   &   $
��Left=�6B   $��25��6]   $��2,3,0,0q�6i   $
 Wrap=�6z   $	��Top=�6�   $	��140��6�   $��2q�6�   6�   �� 5�      ->   5        $ userIdsListBox��5�   &   $
��Left=�6>   $��71��6Y   $��2,33,0,0q�6e   $	��Top=�6w   $	��326��6�   $��2q�6�   6�   5�      5�      �� 5�      -?   5        $��UserInfoGroupUser��5�      $��User Information��68   $��Center=�6R   $��360,0,285.6,0q�6o   $	��400��6�   $	��134��6�   $	��Top=�6�   $��2q�6�   .��5�      � .+�5�      �� -@   5        $ 	nameLabel��5�   $   $
��Name��67   $
��Left=�6F   $��20��6a   $��Center=�6m   $��37��6�   $��9(�6�   $ 0.649,-0.762&�6�   $��
0,3,0,82.6q�6�   �� 5�      -A   5        $ 	starLabel��5�   $   $
��Star��67   $
��Left=�6F   $��20��6a   $��Center=�6m   $��37��6�   $��9(�6�   $ 0.649,-0.762&�6�   $��0,24,0,61.6q�6�   �� 5�      -B   5        $ 	fansLabel��5�   $   $
��Fans��67   $
��Left=�6F   $��20��6a   $��Center=�6m   $��37��6�   $��9(�6�   $ 0.649,-0.762&�6�   $��0,36,0,25.6q�6�   �� 5�      -C   5        $ yelpingSinceLabel��5�   $   $��Yelping Since��6?   $
��Left=�6W   $��26��6r   $��Center=�6~   $��62��6�   $��9(�6�   $ 0.649,-0.762&�6�   $��0,56,0,-0.4q�6�   �� 5�      -D   5        $ nameTextBox��5�   &   $
��Left=�6;   $��15��6V   $��71,8,0,0q�6b   $
 Wrap=�6t   $	��Top=�6�   $	��108��6�   $	��8.5(�6�   {�.  6�   �� 5�      -E   5        $ starTextBox��5�   &   $
��Left=�6;   $��15��6V   $��	71,28,0,0q�6b   $
 Wrap=�6u   $	��Top=�6�   $	��108��6�   $	��8.5(�6�   {�.  6�   �� 5�      -F   5        $ fansTextBox��5�   &   $
��Left=�6;   $��16��6V   $��	71,52,0,0q�6b   $
 Wrap=�6u   $	��Top=�6�   $	��108��6�   $	��8.5(�6�   {�.  6�   �� 5�      -G   5        $ yelpingTextBox��5�   &   $
��Left=�6>   $��15��6Y   $��	71,73,0,0q�6e   $
 Wrap=�6x   $	��Top=�6�   $	��108��6�   $	��8.5(�6�   {�.  6�   �� 5�      -H   5        $ 
votesLabel��5�   $   $��Votes:��68   $
��Left=�6I   $��20��6d   $��Center=�6p   $��37��6�   $��9(�6�   $ 0.649,-0.762&�6�   $��205,4,0,81.6q�6�   �� 5�      -I   5        $ 
funnyLabel��5�   $   $��Funny��68   $
��Left=�6H   $��23��6c   $��Center=�6o   $��37��6�   $��9(�6�   $ 0.649,-0.762&�6�   $��205,20,0,62.6q�6�   �� 5�      -J   5        $ 	coolLabel��5�   $   $
��Cool��67   $
��Left=�6F   $��20��6a   $��Center=�6m   $��37��6�   $��9(�6�   $ 0.649,-0.762&�6�   $��205,43,0,42.6q�6�   �� 5�      -K   5        $ usefulLabel��5�   $   $��Useful��69   $
��Left=�6J   $��20��6e   $��Center=�6q   $��37��6�   $��9(�6�   $ 0.649,-0.762&�6�   $��205,63,0,22.6q�6�   �� 5�      -L   5        $ funnyTextBox��5�   &   $
��Left=�6<   $��15��6W   $��
242,24,0,0q�6c   $
 Wrap=�6w   $	��Top=�6�   $	��108��6�   $	��8.5(�6�   {�.  6�   �� 5�      -M   5        $ coolTextBox��5�   &   $
��Left=�6;   $��15��6V   $��
242,48,0,0q�6b   $
 Wrap=�6v   $	��Top=�6�   $	��108��6�   $	��8.5(�6�   {�.  6�   �� 5�      -N   5        $ usefulTextBox��5�   &   $
��Left=�6=   $��15��6X   $��
242,68,0,0q�6d   $
 Wrap=�6x   $	��Top=�6�   $	��108��6�   $	��8.5(�6�   {�.  6�   5�      5�      �� 5�      -O   5        $��SetUserLocationBox��5�      $��Set User Location��69   $
��Left=�6T   $��	765,0,0,0q�6o   $	��271��6�   $	��134��6�   $	��Top=�6�   $��2q�6�   .��5�      � .+�5�      �� -P   5        $ longitudeLabel��5�   $   $��	Longitude��6<   $
��Left=�6P   $��24��6k   $��1,0,0,0q�6w   $	��Top=�6�   $��55��6�   $��10(�6�   �� 5�      -Q   5        $ latitudeLabel��5�   $   $��Latitude��6;   $
��Left=�6N   $��24��6i   $��
1,0,0,56.6q�6u   $��Bottom=�6�   $��55��6�   $��10(�6�   �� 5�      -R   5        $ longitudeTextBox��5�   &   $
��Left=�6@   $��20��6[   $��61,0,0,0q�6g   $
 Wrap=�6y   $	��Top=�6�   $	��187��6�   $��9(�6�   �� 5�      -S   5        $ latitudeTextBox��5�   &   $
��Left=�6?   $��20��6Z   $��	61,25,0,0q�6f   $
 Wrap=�6y   $	��Top=�6�   $	��187��6�   $��9(�6�   �� 5�      -T   5         ��Name$ setLocationButton��5�   %   $��Set Location��6@   $
��Left=�6W   $��22��6r   $��
164,50,0,0q�6~   $	��Top=�6�   $��84��6�   $��12(�6�   $��2q�6�   6�   5�      5�      �� 5�      -U   5        $��
FriendsBox��5�      $��Friends��61   $
��Left=�6B   $��10,134,0,10q�6]   $	��317��6r   $��2q�6~   .��5�      � .+�5�        -V   5          Name$ friendDataGrid��5�   '   $
��Left=�6?   $	��444��6Z   $��	10,10,0,0q�6g   $	��Top=�6z   $	��284��6�   6�   �� 5�      -W   5        $ removeFriend��5�   %   $��Remove Friend��6;   $
��Left=�6S   $��34��6n   $��
10,459,0,0q�6z   $	��Top=�6�   $��97��6�   $��12(�6�   $��2q�6�   6�   5�      5�      �� 5�      -X   5        $��reviewsByFriendsBox��5�      $��Reviews By Friends��6:   $��Right=�6V   $��0,134,9.6,10q�6r   $	��704��6�   $��2q�6�   .��5�      � .+�5�        -Y   5        $ reviewDataGrid��5�   '   $
��Left=�6?   $	��480��6Z   $��	10,32,0,0q�6g   $	��Top=�6z   $	��678��6�   �� 5�      $0��*Latest reviews posted by the users friends��6$   $
��Left=�6Y   $��32��6t   $��10,0,0,0q�6�   $	��Top=�6�   $	��309��6�   5�      5�      5�      5�      5�      5�      5�      