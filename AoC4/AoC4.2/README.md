Important note for this part of the challenge: it is **very** inefficient. Even for a decent Ryzen 5 5600, it took several seconds to compute the answer. But it does work properly.

I didn't spend too much time on this because it was almost 8am and I hadn't slept at all so I didn't wanna drag this out longer.

One way to optimize it though, is to replace the GetScore method with a readonly property that's calculated upon instantiation. Given the size of the loops, it should probably cut the time it takes to a second or less.