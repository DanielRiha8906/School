from fastapi import FastAPI
from sqlalchemy import Column, Integer, String, create_engine, MetaData
from sqlalchemy.orm import declarative_base, sessionmaker
from pydantic import BaseModel

class Names(BaseModel):
    first_name: str
    last_name: str | None = None
    age: int

Base = declarative_base()

engine = create_engine('sqlite:///:memory:')
metadata = MetaData()
Base.metadata.create_all(engine)  # Vytvoření tabulek
Session = sessionmaker(bind=engine)

class Name(Base):
    __tablename__ = "names"
    id = Column(Integer, primary_key=True, autoincrement=True)
    name = Column(String(25))
    last_name = Column(String(25))
    age = Column(Integer())

fake_names = [
    Names(name="Elon", last_name="Tusk", age=53),
    Names(name="Johnny", last_name="Depp-ression", age=55),
    Names(name="Taylor", last_name="Drift", age=23),
    Names(name="Brad", last_name="Pitstop", age=33),
    Names(name="Angelina", last_name="Joliet", age=48),
    Names(name="Kim", last_name="Carcrashian", age=43),
    Names(name="Leonardo", last_name="DiCapuccino", age=49),
    Names(name="Miley", last_name="Virus", age=31),
    Names(name="Beyoncé", last_name="Knows-all", age=42),
    Names(name="Dwayne 'The pebble'", last_name="Johnson", age=51),
]
session = Session()
session.add_all(fake_names)
session.commit()

app = FastAPI()
@app.get("/")
async def get_name():
    result = session.query(Name).all()
    return result

@app.post("/put")
async def put_name(name_id: int, new_name: str):
    session.query(Name).filter(Name.id == name_id).update({"name": new_name})
    return {"message":f"updated successfuly to {new_name}"}

@app.delete("/del_name/")
async def update_item(name_id: int):
    session.query(Name).filter(Name.id == name_id).delete()
    return {"message": "Item deleted successfully"}

@app.get("/get_names/")
async def get_names(skip: int = 0, limit: int = 0):
    return session.query(Name).limit(limit).offset(skip).all()

@app.put("/names/{name_id}")
async def update_name(name_id: int, name: str):
    return {"Number": name_id, "Name": name}


@app.get("/names/")
async def update_name(name: Names):
    name_dict = name.dict()
    return {"First name:": name.first_name, "Last name": name.last_name}