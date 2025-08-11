"use client";

import Image from "next/image";
import styles from "./page.module.css";
import First from "./components/First";

export default function Home() {
  return (

    <div className={styles.page}>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossOrigin="anonymous"></link>
     <h1>Hello World!!!</h1>
     <hr/>
       <First/>
    </div>
  );
}
