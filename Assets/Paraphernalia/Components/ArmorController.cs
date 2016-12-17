using UnityEngine;
using System.Collections;
using Paraphernalia.Components;
using Paraphernalia.Utils;

public class ArmorController : MonoBehaviour {

	public delegate void OnArmorChanged(float armor, float prevArmor, float maxArmor);
	public event OnArmorChanged onArmorChanged = delegate {};

	public delegate void OnAnyArmorChanged(ArmorController armorController, float armor, float prevArmor, float maxArmor);
	public static event OnAnyArmorChanged onAnyArmorChanged = delegate {};

	public delegate void OnAnyLifeChangeEvent(ArmorController controller);
	public static event OnAnyLifeChangeEvent onAnyDeath = delegate {};

	public delegate void OnLifeChangeEvent();
	public event OnLifeChangeEvent onDeath = delegate {};
	public event OnLifeChangeEvent onDisableArmor = delegate {};
	public event OnLifeChangeEvent onEnableArmor= delegate {};

	public string damageSoundName;
	public string armorDepletedSoundName;
	public string disableSoundName;
	public string armorDepletedParticlesName;
	public string destructionParticlesName;
	public string destructionSpawnName;

	private bool _armorActive;
	public bool armorActive{
		get {
			return _armorActive;
		}
	}

	public float maxArmor = 150;
	public float disableArmor = 0;
	private float _armor;
	public float armor {
		get {
			return _armor;
		}
		set {
			float prevArmor = _armor;
			_armor = value;
			if (_armor > maxArmor) {
				_armor = maxArmor;
			}

			if (_armor <= 0 && prevArmor > 0) {

                if (_armor <= disableArmor && prevArmor > disableArmor) {
					PlayDeactivate();
				}
				else {
					AudioManager.PlayVariedEffect(armorDepletedSoundName);
					//ParticleManager.Play(armorDepletedParticlesName, transform);
				}
			}
			else if (_armor <= disableArmor && prevArmor > disableArmor) {
				PlayDeactivate();
			}
			else if (_armor > 0 && prevArmor <= 0) {
				AudioManager.PlayVariedEffect(armorDepletedSoundName);
				_armorActive = true;
				onEnableArmor();
			}
			else if (_armor < prevArmor) {
				AudioManager.PlayVariedEffect(damageSoundName);
			}
			
			if (prevArmor != _armor) {
				onArmorChanged(_armor, prevArmor, maxArmor);
				onAnyArmorChanged(this, _armor, prevArmor, maxArmor);
			}
		}
	}

	void PlayDeactivate () {
		AudioManager.PlayVariedEffect(disableSoundName);
		//ParticleManager.Play(armorDepletedParticlesName, transform.position);
	}

	public bool isDepleted {
		get { return armor <= 0; }
	}
	
	void Start() {
		_armor = maxArmor;
	}

	public void TakeDamage(float damage, bool allowRecovery = true) {
		armor -= damage;
	}

    public bool Repair(float repair, bool allowRecovery = true)
    {
        if (armor >= maxArmor) return false;
        armor += repair;
        return true;
    }
}
