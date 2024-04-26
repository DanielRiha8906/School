from flask import Flask, render_template, request
from flask_wtf import FlaskForm
from flask_wtf.file import FileField, FileRequired
from wtforms import StringField, TextAreaField, SubmitField, FileField
from wtforms import validators
app = Flask(__name__, template_folder='templates')

user_reviews = {
    "pepa": "Hele fakt bomba website, ale chybi mi tu vlastne vsechno",
    "franta": "Chtel jsem najit recept na smazeny vajicka, ale dostal jsem se tu. Nevi jak.",
    "alena": "Produkt teto firmy je nejlepsi. Pouzivame ho vsichni. Obcas ho pujcime i dedeckovi."
}

@app.route("/")
@app.route("/home")
@app.route("/index")
def index():
    counter = 1
    return render_template("index.html", reviews=user_reviews, view_count=counter)

@app.route("/review/<username>")
def get_review(username):
    if username in user_reviews:
        return f"Returning requested review. {username}:{user_reviews[username]}"
    else:
        return "Username not found in database."

@app.route("/datasets")
def datasets():
    return render_template("datasets.html")

@app.route("/contact", methods=["GET", "POST"])
def contact():
    if request.method == "POST":
        user_name = request.form.get("username")
        user_review = request.form.get("review")
        user_reviews[user_name] = user_review
    return render_template("contact.html")

class ContactForm(FlaskForm):
   username = StringField("User Name:",[validators.DataRequired("Please enter your name.")])
   review = TextAreaField("Review: ", [validators.DataRequired("Please enter website review.")])
   image = FileField(validators=[FileRequired()])
   submit = SubmitField("Send")

class SheepForm(FlaskForm):
   sheepname = StringField("Sheep Name:",[validators.DataRequired("Please enter sheep name.")])
   submit = SubmitField("Send")

if __name__ == "__main__":
    app.run(host="0.0.0.0", port=5000, debug=True)


