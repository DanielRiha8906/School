import asyncio

async def stahuj_shit(source, duration):
    print(f'stahuju z {source}')
    await asyncio.sleep(duration)
    print(f'dostahoval jsem z {source}')

async def main():
    await asyncio.gather(stahuj_shit('soubor1', 5), stahuj_shit('soubor2', 1), stahuj_shit('soubor3', 3))

asyncio.run(main())