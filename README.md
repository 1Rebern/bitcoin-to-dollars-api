# Bitcoin API Converter

C# / .NET desktop application for converting values between dollars and bitcoins using data received through an API.

The project was developed to explore HTTP API communication, JSON processing and desktop application development using Windows Forms.

---

## Project Goal

The goal of the project was to learn how to communicate with a web API from a desktop application and process the returned JSON data.

---

## System Architecture

```text
              ┌──────────────────┐
              │   Windows Forms  │
              │       GUI        │
              └────────┬─────────┘
                       │
                       ▼
              ┌──────────────────┐
              │   HTTP Request   │
              │   System.Net.Http│
              └────────┬─────────┘
                       │
                       ▼
              ┌──────────────────┐
              │       API        │
              └────────┬─────────┘
                       │
                   JSON Response
                       │
                       ▼
              ┌──────────────────┐
              │ JSON Processing  │
              │ System.Text.Json │
              └────────┬─────────┘
                       │
                       ▼
              ┌──────────────────┐
              │ Conversion Logic │
              └────────┬─────────┘
                       │
                       ▼
              ┌──────────────────┐
              │      GUI         │
              │     Result       │
              └──────────────────┘
```

---

## Software

**Programming language:**

- C#

**Platform:**

- .NET

**Namespaces:**

- `System.Net.Http` — HTTP requests
- `System.Text.Json` — JSON parsing and processing
- `System.Windows.Forms` — desktop GUI

---

## How It Works

The application sends an HTTP request to an external API and receives the current exchange-rate information.

The returned JSON data is parsed and processed by the application before the calculated result is displayed through the Windows Forms interface.

---

## Example of Work

<p>
<img src="https://github.com/1Rebern/bitcoin-to-dollars-api/blob/30ebe8b121dde57237956dcd4a132c902405257a/Preview/example.png">
</p>

---

## Engineering Scope

The project demonstrates practical work with:

- HTTP API requests;
- JSON data;
- C# / .NET;
- Windows Forms;
- external data sources;
- basic data conversion.

---
## Project Status

**Status:** Completed learning project.
