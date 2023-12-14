# Fejlesztői Dokumentáció
## Áttekintés
A szimuláció célja egy mezőn zajló ökológiai rendszer szimulálása, amelyben rókák és nyulak interakcióba lépnek egymással és a környezetükkel.

## Osztályok
### Field
#### Properties:

- field: Kétdimenziós tömb a mező állapotainak tárolására.
- foxes: Lista a mezőn található rókákról.
- rabbits: Lista a mezőn található nyulakról.
#### Metódusok:

- DrawField(): Kirajzolja a mezőt a konzolra.
- SetCellColor(row, col): Beállítja a mezők színeit a megadott sor és oszlop alapján.
- FieldGenerator(): Inicializálja a mezőt véletlenszerű állapotokkal, létrehozza a nyulakat és rókákat.
- GrowGrass(): Növeli a fű fejlettségét a mezőn.
- UpdateAsync(): Frissíti a mezőt, végrehajtja a rókák és nyulak lépéseit, szaporodását, illetve a fű növekedését.
- SimulationAsync(): Elindítja a szimulációt, amely ciklusonként frissíti és megjeleníti a mezőt.

### Rabbit
#### Properties:

- Row, Col: A nyúl aktuális pozíciója a mezőn.
- Hunger: A nyúl éhségi szintje.
- rabbit_on: A mező, amin a nyúl található.
#### Metódusok:

- MoveAsync(): Mozgatja a nyulat a mezőn belül, figyelembe véve az éhségi szintet, és kezeli a táplálék elfogyasztását.
- ReproductionAsync(): Ellenőrzi, hogy a nyúl képes-e szaporodni, és ha igen, létrehoz egy új nyulat.
### Fox
#### Properties:

- Row, Col: A róka aktuális pozíciója a mezőn.
- Hunger: A róka éhségi szintje.
- fox_on_field: A mező, amin a róka található.
#### Metódusok:

- MoveAsync(): Mozgatja a rókát a mezőn belül, figyelembe véve az éhségi szintet, és kezeli a táplálék elfogyasztását.
- ReproductionAsync(): Ellenőrzi, hogy a róka képes-e szaporodni, és ha igen, létrehoz egy új rókát.
## Párhuzamos végrehajtás
A rókák és nyulak cselekvéseit párhuzamosan kezeljük aszinkron műveletek segítségével, hogy optimalizáljuk a szimuláció futását.

## Szimuláció ciklus
A szimuláció ciklusokban fut, ahol minden körben frissül a mező és megjelenik a konzolon.
