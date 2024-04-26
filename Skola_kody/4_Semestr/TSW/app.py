from flask import Flask, render_template, request, redirect

app = Flask(__name__)

nabidka = [
{"název": "Le boneless", "cena": 60},
{"název": "Le pizza avec fromag", "cena": 31},
{"název": "le crime de guerre", "cena": 256},
{"název": "grand méchant", "cena": 0},
]
@app.route("/", methods=["GET"])
def index():
    return render_template("template.html")

@app.route("/pizzas", methods=["GET"])
def pizzas():
    return render_template("pizzas.html", les_pizzas=nabidka)

@app.route("/order", methods=["GET", "POST"])
def order():
    if request.method == "POST":
        pica = request.form.get("name")  # Pizza type
        email = request.form.get("email")
        value = int(request.form.get("value"))  # Price per pizza
        for zvolena_pica in nabidka:
            if zvolena_pica["název"] == pica:
                total_order_value = zvolena_pica["cena"] * value
                break
        else:
            total_order_value = "Neplatná objednávka!"

        # Write order details to the file
        with open("faktura.txt", "w") as faktura:
            faktura.write(f"Pizza: {pica}, Total: {total_order_value}, Email: {email}")
        return redirect("/")
    elif request.method == "GET":
        return render_template("orders.html")


if __name__ == "__main__":
    app.run(port=8000, debug=True)
