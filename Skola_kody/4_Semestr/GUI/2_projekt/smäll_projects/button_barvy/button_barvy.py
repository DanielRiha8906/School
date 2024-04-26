from kivy.app import App
from kivy.uix.button import Button
import random


class Priklad(App):
    def build(self):
        self.button = Button(text='Stiskni mě', background_color = (1,1,1,1))
        self.button.bind(on_press=self.klik) #bind přiřazení funkce
        return self.button

    def klik(self, instance):
        self.button.background_color = (random.random(),random.random(),random.random(),1)

Priklad().run()