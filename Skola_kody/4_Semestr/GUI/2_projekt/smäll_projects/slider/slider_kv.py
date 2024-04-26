from kivy.app import App
from kivy.lang.builder import Builder

kv = Builder.load_file("./Slider_kv.kv")


class Priklad(App):
    def build(self):
        return kv

Priklad().run()