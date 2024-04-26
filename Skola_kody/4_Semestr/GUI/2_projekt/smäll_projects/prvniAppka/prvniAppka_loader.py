from kivy.app import App
from kivy.uix.label import Label
from kivy.lang.builder import Builder

class Priklad(App):
    def build(self):
        return Builder.load_string("""
Label:
    color: 1,0,0
    text: "Hi mom"
""")

Priklad().run()