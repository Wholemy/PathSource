# PathSource
Вас ждут передовые разработки, идеально отрисованные кубические пути, ну прямо как в Stroke из WPF исходный код которого недоступен, наслаждайтесь)))

Смещение кривых или увеличение толщины линии кривой, это отдельная головная боль, которая решена мной, путем поиска углов разворота в утолщенных кривых и делением исходной кривой, после чего похожим алгоритмом эта кривая делится окончательно и соединяются поделенные фрагмены, которых может быть гораздо больше чем шесть частей с двумя разворотами) Никакие математические формулы для этого не подходят, только и исключительно деление кривых и их сравнение, поэтому в алгоритмах нет излишней математики кроме сверх необходимой)

![изображение](https://github.com/Wholemy/PathSource/assets/68204631/10a5fcc6-ca0c-4f80-b989-ecb0305d87b7)

![изображение](https://github.com/Wholemy/PathSource/assets/68204631/5fbbfa85-4e0a-4736-8dc8-2a36c56dd31b)

