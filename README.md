## СБОРКА

Для сборки проекта запустите из командной строки autobuild.bat с одним параметром - путь к
csc.exe(C# компилятор). Обычно он расположен C:\Windows\Microsoft.NET\Framework\v4.0.30319.

v4.0.30319 - версия вашего .NET Framework
При отсутствии такого, можите скачать его с https://dotnet.microsoft.com/download

Пример командной строки сборки:
> autobuild.bat C:\Windows\Microsoft.NET\Framework\v4.0.30319

Программа будет собрана в папку bin, расположенную в корневом каталоге.


## ЗАПУСК

1. Для запуска запустите NeuralNetworkRecognitionNumbers.exe.

2. В открывшемся окне в текстовое поле укажите путь до MNIST данных(Папка с t10k-images.idx3-ubyte, ...).
Должны присутствовать все 4 файла!

3. Нажмите кнопку Load. Далее произойдет загруска данных в два этапа, сначала тренировочные
данные, потом тестовые данные.

4. Нажмите кнопку Train для запуска обучения сети. Под лейблами "Train result:" и "Test result:"
будут появляться данные о обученности сети.

Train result - отношение правильных данных ответов ко всему количеству ответов сети за все время обучения
Test result - отношение правильных данных ответов ко всему количеству ответов сети на тестовой выборке.

Roman Doronin, 2019
