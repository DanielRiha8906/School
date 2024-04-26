from kivy.app import App
from kivy.lang.builder import Builder
from kivy.clock import Clock
import random

kv = Builder.load_file("./styl.kv")

class Priklad(App):
    def zmen_barvu(self, dt): # dt = delta time, časový interval od posledního volání funkce
        self.root.ids.tlacitko_clock.background_color = [random.random() for _ in range(3)] + [1]

    def build(self):
        Clock.schedule_interval(self.zmen_barvu, 3)
        return kv

Priklad().run()