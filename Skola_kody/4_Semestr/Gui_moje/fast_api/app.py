from pymongo import MongoClient
from fastapi import FastAPI, Body
from pydantic import BaseModel

app = FastAPI()

# MongoDB connection (replace with your details)
client = MongoClient("localhost", 27017)
db = client["GUI"]
collection = db["qr_codes"]

class QRData(BaseModel):
    user: str
    qr_code: str

@app.post("/guide")
async def save_qr_data(qr_data: QRData = Body(...)):
    # Extract username and QR code from the request
    user = qr_data.user
    qr_code = qr_data.qr_code

    # Insert the data into the MongoDB collection
    result = collection.insert_one({"user": user, "qr_code": qr_code})

    # Return the inserted document ID as confirmation
    return {"message": "QR data saved successfully", "inserted_id": str(result.inserted_id)}
