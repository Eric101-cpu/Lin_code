import random
import statistics
import matplotlib.pyplot as plt

# 抛硬币实验的次数
num_flips = 1000


# 用于存储每次抛硬币的结果
results = []
# 用于存储每次抛硬币后的均值
running_means = []

for _ in range(num_flips):
    # 随机抛硬币，1代表正面 (H)，0代表反面 (T)
    result_idx = random.randint(0, 1)
    results.append(result_idx)   #使用append()方法在列表末尾添加新元素

    # 计算当前所有结果的均值
    mean_idx = statistics.mean(results) #使用statistics模块中的mean()函数计算列表中所有元素的平均值
    running_means.append(mean_idx)  #将当前均值添加到列表中

# 可视化前100次结果均值随次数变化
visual_num = 100
plt.scatter(range(1, visual_num + 1), results[0:visual_num],
           c=results[0:visual_num],marker="o", cmap = 'cool')
#使用scatter()函数绘制散点图，其中x轴为次数，y轴为结果，c参数指定颜色映射，marker参数指定标记类型，cmap参数指定颜色映射类型

plt.plot(range(1, visual_num + 1), results[0:visual_num])
plt.xlabel("Number of coin flips")
plt.ylabel("Result")
plt.grid(True)
plt.show()

# 可视化均值随次数变化
plt.plot(range(1, num_flips + 1), running_means)
plt.axhline(0.5, color = 'r')
plt.xlabel("Number of coin flips")
plt.ylabel("Running Mean")
plt.grid(True)
plt.ylim(0,1)
plt.show()