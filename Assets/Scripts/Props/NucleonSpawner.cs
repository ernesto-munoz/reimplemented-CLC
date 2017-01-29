using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleonSpawner : MonoBehaviour {
	public float timeBetweenSpawn;

	public float spawnDistance;

	public Nucleon[] nucleonPrefabs;

	float timeSinceLastSpawn;

	private void FixedUpdate(){
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn >= timeBetweenSpawn) {
			timeSinceLastSpawn -= timeBetweenSpawn;
			SpawnNucleon ();
		}
	}

	private void SpawnNucleon(){
		Nucleon prefab = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
		Nucleon spawned = Instantiate<Nucleon> (prefab);
		spawned.transform.localPosition = Random.onUnitSphere * spawnDistance;
	}
}
