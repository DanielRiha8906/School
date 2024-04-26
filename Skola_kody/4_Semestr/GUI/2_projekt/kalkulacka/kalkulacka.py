from kivy.app import App
from kivy.uix.boxlayout import BoxLayout
from kivy.uix.gridlayout import GridLayout
from kivy.uix.button import Button
from kivy.uix.textinput import TextInput
from kivy.uix.screenmanager import ScreenManager, Screen
from kivy.core.window import Window
from kivy.utils import platform
import random
class CalculatorWidget(Screen):
    def __init__(self, **kwargs):
        super(CalculatorWidget, self).__init__(**kwargs)

        # Use a BoxLayout with horizontal orientation
        main_layout = BoxLayout(orientation='vertical')
        self.add_widget(main_layout)

        # Create a display area using TextInput
        self.display = TextInput(multiline=False, readonly=True, halign='right', font_size='32sp')
        main_layout.add_widget(self.display)

        # Create GridLayout for buttons with 4 columns
        self.buttons_layout = GridLayout(cols=4, spacing=10)

        # Create buttons and add them to the GridLayout
        buttons = [
            'AC', 'C', 'J', 'Sc',
            '7', '8', '9', '/',
            '4', '5', '6', '*',
            '1', '2', '3', '-',
            '.', '0', '=', '+'
        ]

        for button_text in buttons:
            button = Button(text=button_text, on_press=self.on_button_press, font_size='24sp')
            self.buttons_layout.add_widget(button)

        # Add the GridLayout to the main_layout
        main_layout.add_widget(self.buttons_layout)

    def on_button_press(self, instance):
        if instance.text == '=':
            # Evaluate the expression and update the display
            try:
                result = str(eval(self.display.text))
                self.display.text = result
            except Exception as e:
                self.display.text = "Error"
        elif instance.text == 'C':
            # Clear last digit
            self.display.text = self.display.text[:-1]
        elif instance.text == 'AC':
            # Clear the display
            self.display.text = ""
        elif instance.text == '.':

            if "." not in self.display.text:
                self.display.text += "."
        elif instance.text == 'J':
        # Change the color of all buttons
            for button in self.buttons_layout.children:
                button.background_color = (random.random(),random.random(),random.random(),random.random()/2)

        else:
            # Update the display with the pressed button value
            current_text = self.display.text
            current_text += instance.text
            self.display.text = current_text

class CalculatorManager(ScreenManager):
    pass

class MyApp(App):
    def build(self):
        if platform == 'android' or platform == 'ios':
            Window.maximize()
        else:
            Window.size = (350, 600)

        manager = CalculatorManager()
        calculator_screen = CalculatorWidget(name='calculator')
        manager.add_widget(calculator_screen)

        return manager

if __name__ == '__main__':
    MyApp().run()