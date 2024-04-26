import numpy as np
import matplotlib.pyplot as plt

class Thief:
    capacity = 100
    def __init__(self, possible_items: list):
        self.possible_items = possible_items
        self.inventory = [0] * len(possible_items)

    def take_item(self, item):
        self.current_weight += item.weight
        index = self.possible_items.index(item)
        self.inventory[index] = 1

    @property
    def current_weight(self):
        return sum(item.weight * has_item for item, has_item in zip(self.possible_items, self.inventory))
    @property
    def total_cost(self):
        return sum(item.cost * has_item for item, has_item in zip(self.possible_items, self.inventory))
    @property
    def is_overweight(self):
        return self.current_weight > self.capacity


class Item:
    def __init__(self, cost, weight):
        self.cost = cost
        self.weight = weight
    @property
    def weight(self):
        return self.weight
    @property
    def cost(self):
        return self.cost

def fitness_function(thief):
    if thief.is_overweight:
        return -1
    else:
        return thief.total_cost

television = Item(100, 1000)
phone = Item(35, 230)
ps4 = Item(25, 400)
misc = Item (5, 10)

list_of_items = [television,phone, ps4, misc]

thief1 = Thief(list_of_items)

def initialize_population(population_size, possible_items):
    population = []
    for _ in range(population_size):
        new_thief = Thief(possible_items)
        for item in possible_items:
            if np.random.rand() < 0.5:
                new_thief.take_item(item)
        population.append(new_thief)
    return population
def evolve_population(population, num_generations):
    for generation in range(num_generations):

        fitness_scores = [fitness_function(thief) for thief in population]
        return population

population_size = 10
num_generations = 100
initial_population = initialize_population(population_size, list_of_items)
final_population = evolve_population(initial_population, num_generations)
# převodník gamma. Gamma(alpha) -> x, které dokáže přijmout fit fci -
#
#
#

#OOP NOT A GOOD IDEA