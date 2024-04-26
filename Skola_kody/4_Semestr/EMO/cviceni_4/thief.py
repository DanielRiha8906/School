import random

items = {
  "Television" : {
    "cost" : 1000,
    "weight" : 100
  },
  "phone" : {
    "cost" : 35,
    "weight" : 250
  },
  "PS" : {
    "weight" : 50,
    "cost" : 450,
  },
  "misc" : {
    "cost" : 5,
    "weight" : 10
  },
  "cat": {
    "cost" : 100,
    "weight" : 100
  },
  "cabel":{
    "cost" : 10,
    "weight" : 10
  }

}

thief = ""
for i in items:
    thief += random.choice(["0", "1"])

print(thief)

def fitness(thief):
    list = []
    for i in thief:
        if i == "1":
            list.append(items[i])
