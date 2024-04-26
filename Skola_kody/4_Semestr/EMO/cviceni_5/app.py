# Počet měst si nastávím zatím staticky. Let's go with 4
import numpy as np
import random

Number_of_cities = 4
weight_array = np.array([[0, 2, 1, 4],
                         [1, 0, 4, 3],
                         [7, 1000, 0, 2],
                         [4, 1, 6, 0]])
places = [0, 1, 2, 3]
pocet_jedincu = 5
population = [places.copy() for _ in range(pocet_jedincu)]
for ipop in range(len(population)):
    random.shuffle(population[ipop])
print(population)

def fitness(traveler):
    total_distance = 0
    for i in range(Number_of_cities - 1):
        current_city = traveler[i]
        next_city = traveler[i + 1]
        total_distance += weight_array[current_city, next_city]
    total_distance += weight_array[traveler[-1], traveler[0]]
    return total_distance
# stochasticky

min_fitness = float('inf')
min_index = -1
for i in range(pocet_jedincu):
    current_fitness = fitness(population[i])
    if current_fitness < min_fitness:
        min_fitness = current_fitness
        min_index = i

print("Minimum fitness value:", min_fitness)
print("Index of the fittest individual:", min_index)
print("Fittest individual:", population[min_index])


def evoluce(population):
    pass
#

#začne to v nule, pojede do 3 -> vybere první matici, a najde si poslední index



