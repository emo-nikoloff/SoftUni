# Напишете програма, която пресмята нужните разходи за закупуването на храна за кучета и котки. Храната се пазарува от зоомагазин, като една опаковка храна за кучета е на цена 2.50 лв, а опаковка храна за котки струва 4 лв.
dogFood = float(input())
catFood = int(input())
dogFoodPrice = 2.5
catFoodPrice = 4
print(f"{dogFood * dogFoodPrice + catFood * catFoodPrice} lv.")
