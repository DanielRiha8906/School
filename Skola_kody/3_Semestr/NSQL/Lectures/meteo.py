import datetime
from pymongo import MongoClient

def get_database(name):
    client = MongoClient("mongodb://localhost:27017/")
    return client[name]

def populate(c):
    import csv
    data = []
    with open('meteo.csv', newline='') as csvfile:
        reader = csv.DictReader(csvfile)
        for row in reader:
            item = {"time": datetime._IsoCalendarDate(row["datetime"]), "temp": float(row["outtemp"])}
            print(item)
            data.append(item)
    c.insert_many(data)

c = get_database("NoSQL_2023")["meteo"]
populate(c) 
result = c.aggregate([
    {
        '$project': {
            'mh': {
                '$in': [
                    {'$dateToString': {'date': '$time', 'format': '%H:%M'}},
                    ['07:00', '14:00', '21:00']
                ]
            },
            'temp': '$temp',
            'hour': {'$dateToString': {'date': '$time', 'format': '%H'}},
            'date': {'$dateToString': {'date': '$time', 'format': '%d-%m-%Y'}}
        }
    },
    {
        '$match': {'mh': True}
    },
    {
        '$project': {
            'date': '$date',
            'temp': {'$cond': [{'$eq': ['$hour', '21']}, {'$multiply': ['$temp', 2]}, '$temp']}
        }
    },
    {
        '$group': {
            '_id': '$date',
            'mean': {'$sum': '$temp'}
        }
    }
])
for item in c.find():
    print(item)