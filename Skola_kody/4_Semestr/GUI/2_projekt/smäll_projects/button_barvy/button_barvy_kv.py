from kivy.app import App
from kivy.lang.builder import Builder
import random

kv = Builder.load_file("./button_barvy.kv")

class Priklad(App):
    def build(self):
        return kv

    def klik(self):
        return (random.random(),random.random(),random.random(),1)

Priklad().run()