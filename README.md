# Design Patterns utilizate

## 1. Strategy

- Definită de interfața `IActionStrategy` și de implementările concrete: `BasicAttack`, `Fireball`, `HealSpell` și `EnemyAttack`.
- Folosită în `GameEngine.PlayerAction()` și în `Character.PerformAction()`.

**Scop:**

- Cod mai modular și ușor de extins.
- Dacă vrem să adăugăm abilități noi, se poate crea doar o clasă nouă care implementează strategia → respectă **Open/Closed Principle**.

---

## 2. Factory

- Caracterele, inamicii și zonele lor sunt create în `CharacterFactory`, care permite crearea obiectelor fără a specifica clasa concretă care va fi instanțiată.
- `GameEngine.Initialize()` folosește Factory pentru a crea caractere și inamici noi.
- `Index.cshtml.cs` folosește Factory pentru a genera inamici noi atunci când se selectează o zonă nouă.

**Scop:**

- Cod mai modular și mai ușor de întreținut.
- Obiectele sunt create într-un singur loc → respectă **Single Responsibility Principle**.

---

## 3. Legătura dintre cele două pattern-uri

- Factory creează obiectele specifice caracterelor sau inamicilor.
- Obiectele respective folosesc Strategy pentru a executa acțiuni concrete.
