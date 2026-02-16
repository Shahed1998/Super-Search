# Super Search 🔍

A high-performance search and indexing system that bridges the gap between structured relational data and high-speed search. **Super Search** retrieves data from MS SQL Server, indexes it into Apache Solr, and exposes it via a scalable REST API.

This system is designed for applications that require low-latency search, advanced filtering, and high-volume data querying.

---

## 🏗️ Architecture Overview

```
MS SQL Server
↓
Logstash
↓
Apache Solr
↓
Search API
↓
Client Applications
```
---
## 🚀 How It Works

```text
💡 Data Storage (MS SQL Server)
Business and transactional data is stored in MS SQL Server tables or views.

💡 Data Ingestion (Logstash)
Logstash connects to MS SQL Server using the JDBC input plugin, retrieves data, optionally transforms it, and sends it to Apache Solr.

💡 Indexing & Search (Apache Solr)
Apache Solr indexes the incoming data and provides fast full-text search, filtering, sorting, and faceting capabilities.

💡 Search API
A RESTful API queries Solr and returns search results to client applications such as web or backend services.
```
---

## ✨ Features

```
✅ Fast and scalable search

✅ Near real-time data synchronization

✅ Supports large datasets

✅ Clean separation of data ingestion and search

✅ API-driven access
```

## 📌 Prerequisites

```
⭐ MS SQL Server

⭐ Logstash (with JDBC plugin)

⭐ Apache Solr and JAVA_HOME Environment Variable

⭐ REST API service (ASP.NET / Java / Node.js, etc.)
```

